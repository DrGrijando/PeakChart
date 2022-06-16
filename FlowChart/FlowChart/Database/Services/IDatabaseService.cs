namespace FlowChart.Database.Services
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    public interface IDatabaseService
    {
        /// <summary>
        /// Gets the current month information.
        /// </summary>
        ReadingMonth CurrentMonth { get; }

        /// <summary>
        /// Initialize service and database.
        /// </summary>
        /// <returns></returns>
        Task InitializeAsync();

        /// <summary>
        /// Obtain all the months from the database.
        /// </summary>
        /// <returns></returns>
        Task<List<ReadingMonth>> GetMonthsAsync();

        /// <summary>
        /// Obtain the readings for a specific month.
        /// </summary>
        /// <param name="monthId">The ID of the month to obtain in the database.</param>
        /// <returns>The readings for the given month.</returns>
        Task<List<Reading>> GetMonthAsync(int monthId);

        /// <summary>
        /// Obtaing the readings of a specific month.
        /// </summary>
        /// <param name="date">The date of the month to obtain.</param>
        /// <returns>The readings for the given month.</returns>
        Task<List<Reading>> GetMonthAsync(DateTime date);

        /// <summary>
        /// Insert a reading in the database.
        /// </summary>
        /// <param name="reading">The new reading.</param>
        /// <returns>The ID of the new reading.</returns>
        Task<int> InsertReadingAsync(Reading reading);

        /// <summary>
        /// Update a reading from the database.
        /// </summary>
        /// <param name="reading">The reading to update.</param>
        /// <returns>Whether the operation was a success or not.</returns>
        Task<bool> UpdateReadingAsync(Reading reading);

        /// <summary>
        /// Delete a reading from the database.
        /// </summary>
        /// <param name="reading">The reading to delete.</param>
        /// <returns>Whether the operation was a success or not.</returns>
        Task<bool> DeleteReadingAsync(Reading reading);

        /// <summary>
        /// Clear all records from the database.
        /// </summary>
        /// <returns></returns>
        Task ClearDatabaseAsync();




        Task InsertNewMonthTest(int month, int year);
    }
}
