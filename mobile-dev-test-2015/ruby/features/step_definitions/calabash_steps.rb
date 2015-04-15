require 'calabash-android/calabash_steps'

Given(/^I start the app$/) do
  @startpage = page(StartPage).await timeout:60
end

Then(/^I can get to the Start Page$/) do
  @startpage.dismissDialog
end

When(/^I select the conference$/) do
  @startpage.confe
end

Then(/^I should be on the Conference Page$/) do
  @confPage = page(ConfPage).await timeout:60
end

When(/^I go to the "([^"]*)" page$/) do |arg|
  @confPage.toSubPage(arg)
end

Then(/^I can search by Name$/) do
  @confPage.searchName
end

Then(/^I can try to find "([^"]*)" by scroll$/) do |arg|
  @confPage.searchScroll(arg)
end

Then(/^I can also search for "([^"]*)" with the bar$/) do |arg|
  @confPage.searchBar(arg)
end

And(/^I can select the first result$/) do
  touch "* id:'list_item_title' text:'Xamarin'"
  wait_for_elements_exist ["* text:'Xamarin'"]
end