

## Index

1. Instructions
1. Tests
    1. Web UI tests
1. Improvements that I could have made
1. Executing tests from command line
    1. Run Selenium tests
1. Executing tests from visual studio 

## Instructions

Author : Malinda Wickramasinghe

1. Automation framework and code have been implemented using .NET Core 3.0 
2. I have used Microsoft Visual Studio Community 2019 as the IDE during development. 
3. If you wish to run tests from visual studio, you need to have Visual studio with specflow visual studio plugin (https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowForVisualStudio). Tests can be run from command line without using VS as well. Please check the 'Executing tests from command line' section below for more information.
4. chromedriver.exe version 99.0.4844.5100 and GeckoDriver.exe version 0.30.0.1 is required to run the tests.
7. Make sure chromedriver.exe is not being used by any other process during test execution.


## Tests

### Web UI tests

1. Use Specflow/Webdriver and BDD approach

## Improvements that I could have made

1. Web UI tests don't have a Logger implemented.
2. Can implement a HTML report generating capability after a test run to see the pass/fail status and stats
3. Screen-shots can be captured before and after every step and embed in the HTML report.
4. WebDriverFactory can be improved to run the tests using any other browser or even on mobiles using appium and RemoteWebDriver
6. Can add more hooks (Before after features / Before after steps) to gather vital information such as time taken to execute each steps to identify bottlenecks
7. Folder structure can be improved.

## Executing tests from command line

### Run Selenium tests
1. Navigate to Api test folder where you can find the *.csproj file e.g. 
C:\Users\xxxx\source\repos\Jupiter.Automation\JupiterToys.Automation.Test
2. Open command line and run "dotnet test -v m --logger trx JupiterToys.Automation.Test.csproj"
3. After test run is finished , open TestResults to see the test result trx file

## Executing tests from visual studio 

1. Select Tests > Windows > Test Explorer from the Visual studio menu
2. After successful compilation, you should see tests in the Test Explorer panel.
3. Right-click and run all or selected tests
