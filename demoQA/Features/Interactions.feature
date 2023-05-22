Feature: Interactions

Interactions test scenarios

Scenario: Verify Descending Order Sorting
	Given I am on the "Interactions" panel
	When I navigate to "Sortable" page
	And I sorted the list in descending order
	Then list should be ordered in descending

Scenario: Verify Successful Drag and Drop
	Given I am on the "Interactions" panel
	When I navigate to "Droppable" page
	And I drag the word "Drag me" box to "Drop here" box
	Then I should see the message "Dropped!"
	And the drop here box should turn steelblue