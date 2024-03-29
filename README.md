# Warehouse Manager
Desktop Application for Warehouse Management using WPF framework
 - use Factory pattern to manage Objects for Export
      + #### Factory pattern applies for the Processes with various types such as Export(CSV, Excel. PDF), Import many tables, Payment(Cash, Zalo, Visa)
 - use Singleton pattern to create DataProvider layer between DB Model and ViewModel
      + #### Use the Singleton pattern when a classs in your program should have just a single instance available to all clients; for example, a single database  or object or Resource Provider shared by different parts of the program
 - use MD5CryptoService to encrypt password
 - use Epplus library to export Excel files
 - use Transaction to wrap CRUD operation. 
   - Reference: https://entityframeworkcore.com/saving-data-transaction
 - use Log4Net to log Info and Error. 
   - Reference: https://docs.microsoft.com/en-us/answers/questions/143466/log4net-in-wpf-application.html
 - use Live Visual Tree to inspect XAML properties. 
   - Under Tools > Options > Debugging > General > Enable UI Debugging Toos for XAML
   - Reference: https://docs.microsoft.com/en-us/visualstudio/xaml-tools/inspect-xaml-properties-while-debugging?view=vs-2019
### MVC vs MVVM: Key Differences: 
 - In MVC, controller is the entry point to the Application, while in MVVM, the view is the entry point to the Application.
 - MVC architecture has “one to many” relationships between Controller & View while in MVVM architecture, “one to many” relationships between View & View Model.
### Reference: 
 - https://www.c-sharpcorner.com/UploadFile/puranindia/wpf-interview-questions-and-answers/
 - https://www.c-sharpcorner.com/UploadFile/0b73e1/mvvm-model-view-viewmodel-introduction-part-2/
 - https://www.c-sharpcorner.com/UploadFile/87b416/wpf-value-converters/
 - https://edwardthienhoang.wordpress.com/2018/01/10/cac-khai-niem-can-ban-trong-kien-truc-phan-mem/
 - #### Difference between Excel Vs CSV: https://www.guru99.com/excel-vs-csv.html
