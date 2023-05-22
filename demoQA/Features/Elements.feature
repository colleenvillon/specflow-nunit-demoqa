Feature: Elements

Elements widget test scenarios

Scenario Outline: Verification of Details Post Submission in Text Box
	Given I am on the "Elements" panel
	When I navigate to "TextBox" page
	And I fill out the text box form with the following data:
	| FullName		 | Email				| CurrentAddress		| PermanentAddress	 |
	| <FullName>	 | <Email>				| <CurrentAddress>      | <PermanentAddress> |
	And I click the submit button
	Then <FullName>, <Email>, <CurrentAddress>, and <PermanentAddress> should be visible on the page
	Examples:
	|FullName	   |Email			     |CurrentAddress	   |PermanentAddress   |
	|Colleen Villon|colleen@test.com	 |Manila,Philippines   |Manila, Philippines|

Scenario Outline: Verification of Selected Checkboxes in Checkbox Page
	Given I am on the "Elements" panel
	When I navigate to "Checkbox" page
	And I select the <CheckBoxName> checkbox
	Then <CheckBoxName> checkbox should be selected
	Examples:
	|CheckBoxName	   |
	|Home			   |

Scenario Outline: Updating a Record in Web Tables
	Given I am on the "Elements" panel
	When I navigate to "Web Tables" page
	And I update the <recordOrder> record with the following data:
	| FirstName   | LastName   | Age   | Email   | Salary  | Department			  |
	| <FirstName> | <LastName> | <Age> | <Email> | <Salary> | <Department>        |
	And I click the submit button
	Then The recordOrder:<recordOrder> with data <FirstName>, <LastName>, <Age>, <Email>, <Salary> and <Department> should be updated and visible on the web table
	Examples:
	| recordOrder | FirstName | LastName | Age | Email            | Salary | Department |
	| 1           | Colleen   | Villon   | 29  | colleen@test.com | 5000   | QA         |

Scenario: Verification of Message Displayed on Button Click
	Given I am on the "Elements" panel
	When I navigate to "Buttons" page
	And I click "Click Me" button
	Then I should see the message "You have done a dynamic click"

Scenario: Verify File Download and Upload
	Given I am on the "Elements" panel
	When I navigate to "Upload and Download" page
	And I click "Download" button
	Then I should be able to see "sampleFile.jpeg" on my downloads folder
	When I upload a file "sampleFile.jpeg" from my downloads folder
	Then I should see the message "C:\fakepath\sampleFile.jpeg"