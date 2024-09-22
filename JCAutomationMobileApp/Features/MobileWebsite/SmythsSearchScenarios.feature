@Firefox
Feature: SmythsSearchScenarios

Examining search functionality for Smyths

Scenario: valid search term brings up valid results
    Given I go to the home page
    When I search for the term "grogu"
    Then I will find the search term "grogu" in the search results

Scenario: user is informed that no search results are found for invalid keyword
    Given I go to the home page
    When I search for the term "43435543345gredferwerewrwer"
    Then I will be told that there were no items found