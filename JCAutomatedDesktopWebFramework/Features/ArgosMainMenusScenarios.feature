@NoAccountNeeded
Feature: ArgosMainMenusScenarios

As a customer of the website I wish to be able to easily view all the main categories of products you stock, but also see new and trending items and categories

Scenario: A customer can see a the main product categories at a glance
	Given I am on the "home" page
	When I interact with the "Shop" text
	Then I can see product categories including
      | expectedText |
      | Home & Furniture |
      | Technology |
      | Garden & DIY |
      | Toys |
      | Clothing |
      | Inspiration |

Scenario: Hovering over the trending text reveals a list of product categories
	Given I am on the "home" page
	When I interact with the "Trending" text
	Then I can see product categories including
      | expectedText    |
      | New In |
      | Clearance |
