# BDD SpecFlow Webdriver Nunit Framework
BDD designed Test automation framework built in C#, Specflow, NUnit and MSTest

# Installation
## Getting Started
1. Download and install latest Visual Studio Community edition
2. Install the necessary NuGet packages: <br />
Right-click on your project in the Solution Explorer and select Manage NuGet Packages.
In the Browse tab, search for and install the following packages:<br />
SpecFlow<br />
Specflow.NUnit<br />
SpecFlow.MsTest<br />
Selenium.Support<br />
Selenium.WebDriver<br />
Selenium.WebDriver.ChromeDriver<br />
NUnit<br />
NUnit3TestAdapter<br />
Microsoft.Net.Test.Sdk<br />
MSTest.TestAdapter<br />
MSTest.TestAdapter<br />
DotNetSelenium.WaitHelpers<br />
3. Install **Specflow for Visual Studio 2022** Extension. Navigate to Extension > Manage Extension > Download/Install Specflow from Visual Studio MarketPlace
  
## Usage
1. To run the test using Test Explorer. Navigate to Test > Test Explorer, Right click the test name then click RUN

2. To run the test on command line: <br />
Open the command prompt or terminal.<br />
Navigate to the root project directory that contains your SpecFlow tests.<br />
type in the commandline: **dotnet test**

## Configuration
1. **BEFORE RUNNING THE TEST**, add this two environment variables: <br />
VARIABLE NAME: DEMOQA_PASSWORD  <br />
VARIABLE VALUE: Test750!!     <br />
VARIABLE NAME: DEMOQA_USERNAME  <br />
VARIABLE VALUE: colleenqa  <br />

## Note
1. Test Scenario **"Register on Book Store Application"** is FAILING DUE TO **IMAGE CAPTCHA CODE** IN REGISTRATION FORM
2. After setting up Environment variables on the Configurate step, make sure to **restart** your Visual Studio IDE before rerunning the tests

## Last execution Result (05/23/2023)
![image](https://github.com/colleenvillon/specflow-nunit-demoqa/assets/22775062/234596b6-66da-4c14-a4fc-a91bc3d47016)

