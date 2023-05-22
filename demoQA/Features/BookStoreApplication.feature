Feature: Book Store Application

Book Store Application test scenarios

Scenario Outline: Register on Book Store Application-- FAILING DUE TO CAPTCHA CODE IN REGISTRATION FORM)
	Given I am on the "Book Store Application" panel
	When I navigate to "Login Book Store App" page
	And I register with the following data:
	| FirstName   | LastName   | UserName   | Password   |
	| <FirstName> | <LastName> | <UserName> | <Password> |
	Then I should "be" able to login using <UserName> and <Password>
	Examples:
	| FirstName | LastName | UserName  | Password  |
	| Colleen   | Villon   | env_var   | env_var   |

Scenario Outline: Login using registered credentials
	Given I am on the "Book Store Application" panel
	When I navigate to "Login Book Store App" page
	And I login using this credential:
	| UserName   | Password   |
	| <UserName> | <Password> |
	Then I should "be" able to login and see profile account
	Examples:
	| UserName  | Password  |
	| env_var   | env_var   |

Scenario Outline: Login using using invalid credentials
	Given I am on the "Book Store Application" panel
	When I navigate to "Login Book Store App" page
	And I login using this credential:
	| UserName   | Password   |
	| <UserName> | <Password> |
	Then I should see the message "Invalid username or password!"
	Examples:
	| UserName  | Password  |
	| env_var   | invalid   |