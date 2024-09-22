Feature: ArgosTrolleyScenarios

As a customer I want to be able to add one or more items to my trolley, so I can purchase multiple items at once

Background: Customer is logged in into their account
	Given I am on the "home" page
	But I am not logged in
	And I navigate to the account page
	And I enter valid account credentials
	When I attempt to sign into my account
	Then I am logged in to my account

Scenario: A customer can view their trolley once logged in
	When I navigate to the "trolley" page
	Then I can see my trolley

Scenario: A customer can search for a particular term and add an item from the results to their trolley
	Given I search for "Switch Console"
	When I add the product to my trolley
	Then I will see the product in my trolley
	And I can remove the item from my trolley

