@Firefox
Feature: SmythsHomeScenarios

As an Smyths Toys website fullstack developer I want to ensure the home page contains the core details to identify the website at a high level

Scenario: Clicking Smyths logo takes user back to home page
    Given I go to the home page
    And I navigate to a different page
    When I interact with the Smyths logo in the header 
    Then I will arrive back on the home page

@trivial
Scenario: Validate the PageSource string on a web page
    When I go to the home page
    Then I can see "Smyths Toys" in the PageSource

Scenario: User can see shop categories within the home page
    Given I go to the home page
    When I navigate to the shop by category area
    Then I will see the category icons for
      | expectedText |
      | Toys         |
      | Outdoor      |
      | Baby Room    |
      | Gaming       |
      | Gift Finder  |
      | Gift Cards   |
      | Events       |

@normal
Scenario: Validate existence of product categories in side menu
    Given I go to the home page
    When I open the website side menu
    Then I will see in the side menu
      | expectedText  |
      | Toys          |
      | Outdoor       |
      | Baby Room     |
      | Gaming        |
      | Clearance     |
      | Gift Finder   |
      | Shop By Age   |
      | Brand Shops   |
      | Gift Cards    |
      | Events        |
      | Buying Guides |