require 'calabash-android/abase'

class ConfPage < Calabash::ABase

  def trait
    "* text:'Exhibitors'"
  end

  def toSubPage(title)
    tap_mark title
    wait_for_elements_exist ["* {text CONTAINS 'Exhibitors by'}"]
  end

  def searchName
    tap_mark "Exhibitors by Name"
    wait_for_elements_exist ["* id:'cc_event_guide_list_bookmark'"]
  end

  def searchScroll(company)
    for i in 0..2
      sleep 0.5
      scroll_down
      if element_exists "* text:'#{company}'"
        break
      end
    end
  end

  def searchBar(company)
    tap_mark "Search"
    enter_text "* id:'search_bar'", company
    press_enter_button
  end

end