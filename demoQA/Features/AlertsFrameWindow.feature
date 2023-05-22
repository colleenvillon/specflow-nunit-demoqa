Feature: Alerts, Frames and Window

Alerts, Frames and Window widget test scenarios

Scenario: Opening a New Tab and Verifying Page Heading
	Given I am on the "Alerts, Frame & Windows" panel
	When I navigate to "Browser Windows" page
	And I click "New Tab" button
	And I switch to the new "tab"
	Then I should see the "heading" message "This is a sample page"

Scenario: Opening a New Window and Verifying Page Heading
	Given I am on the "Alerts, Frame & Windows" panel
	When I navigate to "Browser Windows" page
	And I click "New Window" button
	And I switch to the new "window"
	Then I should see the "heading" message "This is a sample page"

Scenario: Opening and Switching to a New Window Successfully
	Given I am on the "Alerts, Frame & Windows" panel
	When I navigate to "Browser Windows" page
	And I click "New Window Message" button
	Then I switch to the new "window" successfully

Scenario: Verifying Prompt Box with Name Submission
	Given I am on the "Alerts, Frame & Windows" panel
	When I navigate to "Alerts" page
	And I click "prompt" button option
	And Submit prompt with my name: "Colleen"
	Then I should see the "span" message "You entered Colleen"