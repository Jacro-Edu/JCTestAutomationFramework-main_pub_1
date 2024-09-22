@NoAccountNeeded
Feature: HomeScenarios

As an Argos fullstack developer I want to ensure the home page contains the core details to identify the website at a high level

@trivial
Scenario: Validate the title of a website
	When I go to the "home" page
	Then the page title contains "Argos"

@critical
Scenario: Validate the Url of a webpage
    When I go to the "home" page
    Then the page URL contains "https://www.argos.co.uk"

@normal
Scenario: Validate the Page Source string on a web page
    When I go to the "home" page
    Then "Argos" is in the Page Source

@critical
Scenario: Validate existence of multiple texts in PageSource
    When I go to the "home" page
    Then I see
      | expectedText    |
      | Argos Ltd  |
      | Search |
      | About  |
      | Shop  |
      | Trending  |
      | Account  |
      | Wishlist  |
      | Trolley  |
      | Help  |
      | Contact us  |
      | Accessibility |

@critical
Scenario: Selecting Argos logo takes user back to home page
    Given I am on the "home" page
    And I have navigated to the "New In" page
    When I use the Argos logo
    Then the page URL contains "https://www.argos.co.uk/?clickOrigin=header:home:argos+logo"

@normal
Scenario: Back to top icon appears when user scrolls down page
    Given I am on the "home" page
    And the back to top icon is not visible
    When I scroll down the page
    Then the back to top icon is visible
@normal
Scenario: Back to top icon disappears when user scrolls up page
    Given I am on the "home" page
    When I scroll down the page
    And I scroll to the top of the page
    Then the back to top icon is not visible
@critical
Scenario: Back to top icon takes user to top of page
    Given I am on the "home" page
    And I scroll down the page
    When I select the back to top icon
    Then I will arrive at the top of the page
@critical
Scenario: Main page images have alt text for visual assistance & screen readers
    Given I am on the "home" page
    When I scroll down the page
    Then I can verify that the main banner images have text descriptions
    And I scroll to the top of the page
    And I can verify that the site logo image has a description
@critical
Scenario: Home page URL references user is on the home page
    When I go to the "home" page
    Then the page URL contains "https://www.argos.co.uk/home"
