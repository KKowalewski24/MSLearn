using System;
using Store.Fill;
using Store.Repository;

namespace Store.App {

    class Program {

        /*------------------------ PROPERTY REGION ------------------------*/
        public const int IMPORT_JSON = 1;
        public const int EXPORT_JSON = 2;
        public const int DISPLAY = 3;
        public const int STOP = 4;

        private static DataContext _dataContext = new DataContext();
        private static IDataFiller _dataFiller;
        private static DataRepository _dataRepository;

        /*------------------------ METHODS REGION ------------------------*/
        public static void Menu(ref int choice) {
            Console.WriteLine("Import/Export JSON File");
            Console.WriteLine(IMPORT_JSON + ". Import JSON");
            Console.WriteLine(EXPORT_JSON + ". Export JSON");
            Console.WriteLine(DISPLAY + ". Display");
            Console.WriteLine(STOP + ". Stop");

            Console.Write("Choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
        }

        public static void Main(string[] args) {
            int choice = 0;

            while (choice != STOP) {
                Menu(ref choice);
                switch (choice) {
                    case IMPORT_JSON: {
                        break;
                    }
                    case EXPORT_JSON: {
                        break;
                    }
                    case DISPLAY: {
                        break;
                    }
                    case STOP: {
                        break;
                    }
                    default: {
                        break;
                    }
                }
            }
        }

    }

}
