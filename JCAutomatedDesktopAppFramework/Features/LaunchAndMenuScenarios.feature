Feature: LaunchAndMenuScenarios

As a user, I want to be able to launch the appliction and view the menu items within

Scenario: Launching the app
	When I launch Notepad
	Then the application is launched on a blank screen

Scenario: File Menu contains expected items
	Given I launch Notepad
	When I select "File"
    Then I will see in the "File" menu
      | expectedText    |
      | New tab  |
      | New window |
      | Open |
      | Save  |
      | Save as |
      | Save all |
      | Page setup  |
      | Print  |
      | Close tab  |
      | Close window  |
      | Exit |

Scenario: Edit Menu contains expected items
	Given I launch Notepad
	When I select "Edit"
    Then I will see in the "Edit" menu
      | expectedText    |
      | Undo  |
      | Cut |
      | Paste |
      | Delete  |
      | Find |
      | Find next |
      | Find previous  |
      | Replace  |
      | Go to  |
      | Select all |
      | Time/Date |
      | Font |

Scenario: View Menu contains expected items
	Given I launch Notepad
	When I select "View"
    Then I will see in the "View" menu
      | expectedText    |
      | Zoom  |
      | Status bar |
      | Word wrap |

Scenario: Help option exists in menu
    Given I launch Notepad
    When I select "Help"
    Then I will see in the "Help" menu
      | expectedText    |
      | Help topics  |
      | User Guide |
      | Send feedback |
