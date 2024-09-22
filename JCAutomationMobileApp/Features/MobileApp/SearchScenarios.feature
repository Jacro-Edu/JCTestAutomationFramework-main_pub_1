@Android
Feature: SearchScenarios

As a bargain hunter I want a search feature in the HUKD app which is easily identifable, and I can easily and quickly search for the products I'm interested in finding deals for. The results should be relevant to what I am searching for!

Background: Setup for search tests
    When I go to the app home page
    Then I will see a "Search" icon
     And I can use it to get to the "Search" screen

@critical
Scenario: search tab has an input area for search terms with suggestions
	When I type in the search term "table"
	Then I will see suggestions such as "Garden Table" appear as product categories

@tag1
Scenario: search tab sectional headers remain after removing entered search term
	When I type in the search term "ball"
    And I delete the search term
	Then I will see the following sectional headers
	| Sectional Headers |
	| Top searches  |
	| Categories    |
	| Discussions   |

@critical
Scenario: valid search term returns valid results
	When I search for "LG OLED"
	Then I will find "LG OLED" in the search results

@critcial
Scenario: user is informed of invalid search term
	When I search for "565464d3232wewer\dasdqwewq"
	Then I will be told that no results could be found