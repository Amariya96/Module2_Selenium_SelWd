using Assignments;
using NUnit.Framework;
/*AmazoneTest at = new();
at.InitializeChromeDriver();
at.TitleTest();
at.URLTest();
at.Destruct();
*/
LaunchNewBrowser launchNewBrowser = new LaunchNewBrowser();
try
{
    launchNewBrowser.InitializeChromeDriver(); //calling intialize method
    launchNewBrowser.SearchResultTest(); // calling SearchResulTest  method

}
catch (AssertionException)
{
    Console.WriteLine(" Title Test failed");
}
launchNewBrowser.Destruct();