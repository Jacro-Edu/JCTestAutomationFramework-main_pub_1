@Android
Feature: DealScenarios

As a bargain hunter I want to be able to view a deal on its own page with plenty of details available to me about the deal, such as when it was posted, its heat rating, along with options to save and share it, and t

Background: setup
    Given I go to the app home page
@tag1
Scenario: Validate score functionality exists on a deal page
    When I view an individual deal
    Then I will see the current deal score
    And I can see options to change this score

    Scenario: Deal page has a comments section
    When I view an individual deal
    Then I will see a comments section
    And I will see a way to subscribe to see further comments on the deal

    Scenario: Deal page shows email account of deal poster
    When I view an individual deal
    Then I will see the email address of the deal poster

    Scenario: Comments on a deal can be sorted
    When I view an individual deal
    And I navigate to the comments section
    Then I can see a way to sort the comments
    And I will see the following options
    | expected text      |
    | Top first          |
    | Newest first       |
    | Most helpful first |
    | Oldest first       |

    Scenario: Deal page has options for saving a deal to view later
    When I view an individual deal
    Then I can see a way to save the deal

    Scenario: Deal page has options for navigating to the last comment
    And I view an individual deal
    When I use the shortcut to the last comment
    Then I arrive at the last comment

    Scenario: Deal page has options for sharing the deal with others
    Given I view an individual deal
    When I use the share button
    Then I can see the share screen