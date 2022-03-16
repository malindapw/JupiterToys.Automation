Feature: ContactSubmissionScenarios

	As a user
	I want to submit a feedback form
	So that I can send a feedback about the store 

@smoke
Scenario: Submit the feedback form without filling in the mandatory fields
	Given I have opened the Jupiter Toys page
	And I have navigated to "Contact" page
    And I have left all the mandatory fields empty
	And I have attempted to submit the form
	And I have seen a header message "We welcome your feedback - but we won't get it unless you complete the form correctly."
	And I have seen below validation error messages next to each mandatory fields
	| Field    | Error                |
	| Forename | Forename is required |
	| Email    | Email is required    |
	| Message  | Message is required  |
	When I populate all the mandatory fields with below inputs
	| Forename | Surname | Email                | Telephone  | Message         |
	|    John  |         |  john.wood@gmail.com |            | Shop is awesome |
	Then all the validation errors get disappeared  


Scenario: Successfully submit the feedback form
	Given I have opened the Jupiter Toys page
	And I have navigated to "Contact" page
	And I populate all the fields with below inputs
	| Forename | Surname | Email                | Telephone  | Message         |
	|    Paul  |   Reen  |  john.wood@gmail.com | 09876765   | Shop is awesome |
	When I have attempted to submit the form
	Then I can successfully submit the feedback form

Scenario Outline: Fill the form with invalid mandatory data
	Given I have opened the Jupiter Toys page
	And I have navigated to "Contact" page
	And I populate all the fields with below inputs
	| Forename   | Surname | Email    | Telephone | Message   |
	| <forename> |   Wood  |  <email> | 0112398   | <message> |
	And I have attempted to submit the form
	Then I can see below validation error messages next to each fields
	| Field    | Error                |
	| Forename | Forename is required |
	| Email    | <error email>        |
	| Message  | Message is required  |

	Examples:
	| forename | email     | message   | error email                |
	|          | john.wood |           | Please enter a valid email |
	|          | @gmail    |           | Please enter a valid email |
    |          |           |           | Email is required          |
