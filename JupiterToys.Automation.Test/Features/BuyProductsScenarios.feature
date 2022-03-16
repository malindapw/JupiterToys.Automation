Feature: BuyProductsScenarios

    As a user
	I want to select items 
	So that I can buy added items in the cart 

@smoke
Scenario: Select items from the shop list and add to the cart
	Given I have opened the Jupiter Toys page
	And I have navigated to "Shop" page
	And I have bought below items
	| Item         | Quantity | 
	| Funny Cow    |   2      |
    | Fluffy Bunny |   1      |
	When I open the "Cart"
	Then I can see the selected items in the cart