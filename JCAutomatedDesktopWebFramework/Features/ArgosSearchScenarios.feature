@NoAccountNeeded
Feature: ArgosSearchScenarios

As a customer, I want a way to search for different products, to search via any page I am currently on, and recieve relevant results for my searches

@critical
Scenario: Search bar can be found on the home page
	When I go to the "home" page
	Then I can locate an input for my searches on the "home" page

@critical
Scenario: Search bar can be found on the trolley page
	When I go to the "trolley" page
	Then I can locate an input for my searches on the "trolley" page

@critical
Scenario: Search bar can be found on the wishlist page
	When I go to the "wishlist" page
	Then I can locate an input for my searches on the "wishlist" page

@critical
Scenario: valid search term returns valid results
	Given I am on the "home" page
	When I search for "PS5 Console"
	Then I see valid search results for the term "PS5 Console"

@critcial
Scenario: user is informed of invalid search term
	Given I am on the "home" page
	When I search for "gldfgnklfgvv2"
	Then I am told that no results could be found for the term "gldfgnklfgvv2"

@trivial
Scenario: if a user enters a search term they can quickly remove it from the search input box
	Given I am on the "home" page
	And I enter a search term into the search field such as "text to be cleared"
	When I clear the search input
	Then I will see the search input is cleared

@normal
Scenario: when a customer begins to type a search term in the search area they are provided search suggestions
	Given I am on the "home" page
	And I enter a search term into the search field such as "laptop"
	Then I will see search suggestions
	And I can see relevant search suggestions for the term "laptop"
