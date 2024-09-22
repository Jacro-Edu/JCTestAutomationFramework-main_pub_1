Feature: ArgosWishlistScenarios

As an Argos customer I would like a wishlist feature for my account so that when I see a product I would like to buy, I can store and view it later

Background: Customer is logged in into their account
	Given I am on the "home" page
	But I am not logged in
	And I navigate to the account page
	And I enter valid account credentials
	When I attempt to sign into my account
	Then I am logged in to my account

Scenario: A customer can view their wishlist and once logged in
	When I navigate to the "wishlist" page
	Then I can see my wishlist

Scenario: A customer can add an item to their wishlist & remove it
	Given I search for "PS5 Console"
	When I add the product to my wishlist
	Then I will see the product in my wishlist
	And I can remove the item from my wishlist

