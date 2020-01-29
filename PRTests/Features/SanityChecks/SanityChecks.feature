Feature: Sanity Checks to run as part of every PR

@Critical
Scenario: User journey covering manager authentication to link the device and operator login
    Given the manager login page is displayed 
	When a single site manager authenticates with valid credentials
	And the device is linked
	And the akru module is selected
	And valid operator code is entered using the keypad
	Then the EPOS screen is displayed
