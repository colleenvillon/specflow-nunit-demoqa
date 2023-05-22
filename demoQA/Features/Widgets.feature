Feature: Widgets

Widgets test scenarios

Scenario: Verify Auto Search Complete -  Multiple Color
	Given I am on the "Widgets" panel
	When I navigate to "Auto Complete" page
	And I type "o" on the "Multiple" color textbox
	Then I should see "Yellow, Voilet, Indigo" in order

Scenario: Verify Auto Search Complete -  Single Color
	Given I am on the "Widgets" panel
	When I navigate to "Auto Complete" page
	And I type "Gree" on the "Single" color textbox
	Then I should see "Green" in option

Scenario: Date Picker - Select a Specific Date
	Given I am on the "Widgets" panel
	When I navigate to "Date Picker" page
	And I update the date to "05/02/2023"
	Then "Date" textbox should be updated to "05/02/2023"

Scenario: Date Picker - Select Date and Time
	Given I am on the "Widgets" panel
	When I navigate to "Date Picker" page
	And I change the date to "May 12, 2023" and time to "4:00 AM"
	Then "Date and Time" textbox should be updated to "May 12, 2023 4:00 AM"

Scenario: Validate Tool Tip Information on Hover
	Given I am on the "Widgets" panel
	When I navigate to "Tool Tips" page
	And I hover the word "Contrary"
	Then I should see the "div" message "You hovered over the Contrary"
	When I hover the word "1.10.32"
	Then I should see the "div" message "You hovered over the 1.10.32"