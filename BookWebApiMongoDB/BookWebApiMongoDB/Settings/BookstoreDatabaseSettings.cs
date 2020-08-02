namespace BookWebApiMongoDB.Settings {

    public class BookstoreDatabaseSettings : IBookstoreDatabaseSettings {

        /*----------------------- PROPERTIES REGION ----------------------*/
        public string BooksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        /*------------------------ METHODS REGION ------------------------*/

    }

}
