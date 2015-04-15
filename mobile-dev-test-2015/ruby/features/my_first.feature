Feature: Demo

  Scenario: Finding Ourselves
    Given I start the app
    Then I can get to the Start Page

    When I select the conference
    Then I should be on the Conference Page

    When I go to the "Exhibitors" page
    Then I can search by Name

    Then I can try to find "Xamarin" by scroll
    Then I can also search for "Xamarin" with the bar
    And I can select the first result