@Android
Feature: LaunchScenarios

As a developer I want to be able to launch the app successfully on an emulated device and validate that core navigation and functionality works for getting around the app

Scenario: Validate the title of the app
    When I go to the app home page
    Then I can verify the pagesource references HUKD

Scenario: the home tab icon can be seen
    When I go to the app home page
    Then I will see a "Home" icon
    And it is currently in focus

Scenario: validate application version number
    Given I go to the app home page
    When I open the side menu
    Then the version of the app is "6.21.01"

Scenario: notification icon tab and functionality
    When I go to the app home page
    Then I will see a "Notifications" icon
    And I can use it to get to the "Notifications" screen

Scenario: search icon tab and functionality
    When I go to the app home page
    Then I will see a "Search" icon
     And I can use it to get to the "Search" screen

Scenario: inbox icon tab and functionality
    When I go to the app home page
    Then I will see a "Inbox" icon
     And I can use it to get to the "Inbox" screen

Scenario: profile icon tab and functionality
    When I go to the app home page
    Then I will see a "Profile" icon
     And I can use it to get to the "Profile" screen

Scenario: side menu functionality
    Given I go to the app home page
    When I open the side menu
    Then I will see
    | expectedText   |
    | What's new?    |
    | Categories     |
    | Discussions    |
    | Settings       |
    | FAQ            |
    | About          |
    | Privacy Policy |
    | Feedback       |