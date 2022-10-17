namespace FlowChart.Database.Services
{
    using Models;
    using SQLite;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Xamarin.Essentials;
    
    public class DatabaseService : IDatabaseService
    {
        private readonly SQLiteAsyncConnection db;

        public ReadingMonth CurrentMonth { get; private set; }

        public DatabaseService()
        {
            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FlowChartData.db");
            db = new SQLiteAsyncConnection(databasePath);

            MainThread.BeginInvokeOnMainThread(async () => await InitializeAsync());
        }

        public async Task InitializeAsync() 
        {
            await db.CreateTableAsync<ReadingMonth>();
            await db.CreateTableAsync<Reading>();

            List<ReadingMonth> months = await GetMonthsAsync();
            if (months.Count == 0)
                CurrentMonth = await InsertNewMonth();
            else
            {
                CurrentMonth = months.FirstOrDefault(month => month.Month == DateTime.UtcNow.Month && month.Year == DateTime.UtcNow.Year);
                if (CurrentMonth == null)
                    CurrentMonth = await InsertNewMonth();
            }
        }

        public async Task<List<ReadingMonth>> GetMonthsAsync()
        {
            AsyncTableQuery<ReadingMonth> query = db.Table<ReadingMonth>();
            List<ReadingMonth> months = await query.ToListAsync();
            return months;
        }

        public async Task<List<Reading>> GetMonthAsync(int monthId)
        {
            try
            {
                AsyncTableQuery<Reading> query = db.Table<Reading>().Where(reading => reading.MonthId == monthId);
                List<Reading> readings = await query.ToListAsync();
                return readings;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
                return null;
            }
        }

        public async Task<List<Reading>> GetMonthAsync(DateTime date)
        {
            AsyncTableQuery<ReadingMonth> query = db.Table<ReadingMonth>().Where(month => month.Month == date.Month && month.Year == date.Year);
            ReadingMonth readingMonth = await query.FirstAsync();
            return await GetMonthAsync(readingMonth.Id);
        }

        public async Task<int> InsertReadingAsync(Reading reading)
        {
            reading.MonthId = CurrentMonth.Id;
            await db.InsertAsync(reading);

            CurrentMonth.ReadingCount++;
            if (!string.IsNullOrEmpty(reading.Note))
                CurrentMonth.NoteCount++;

            await db.UpdateAsync(CurrentMonth);

            return reading.Id;
        }

        public async Task<bool> UpdateReadingAsync(Reading reading)
        {
            try
            {
                await db.UpdateAsync(reading);
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> DeleteReadingAsync(Reading reading)
        {
            try 
            {
                await db.DeleteAsync(reading);
                return true;
            }
            catch { return false; }
        }

        public async Task ClearDatabaseAsync() 
        {
            await db.DeleteAllAsync<Reading>();
            await db.DeleteAllAsync<ReadingMonth>();
        }

        private async Task<ReadingMonth> InsertNewMonth() 
        {
            ReadingMonth month = new ReadingMonth()
            {
                Month = DateTime.UtcNow.Month,
                Year = DateTime.UtcNow.Year
            };

            await db.InsertAsync(month);
            return month;
        }

        public async Task InsertNewMonthTest(int month, int year)
        {
            // Create month
            ReadingMonth m = new ReadingMonth()
            {
                Month = month,
                Year = year
            };

            await db.InsertAsync(m);

            // Add readings
            Random rand = new Random();
            List<Reading> readings = new List<Reading>();
            DateTime date = new DateTime(year, month, 1);
            for (int i = 0; i < 30; i++)
            {
                Reading r = new Reading()
                {
                    Date = date,
                    Value = rand.Next(650, 760),
                    MonthId = m.Id
                };
                if (i > 0)
                {
                    r.IsNightPeriod = !readings[i - 1].IsNightPeriod;
                    r.Note = string.IsNullOrEmpty(readings[i-1].Note) ? 
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque euismod ut elit in auctor. Praesent convallis cursus ligula, sit amet accumsan nunc lobortis non." 
                        : null;
                }
                readings.Add(r);
                await db.InsertAsync(r);
                
                m.ReadingCount++;
                if (!string.IsNullOrEmpty(r.Note))
                    m.NoteCount++;

                await db.UpdateAsync(m);

                date = date.AddDays(1);
            }
        }
    }
}
