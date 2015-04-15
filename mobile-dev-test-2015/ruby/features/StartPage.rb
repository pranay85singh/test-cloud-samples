require 'calabash-android/abase'

class StartPage < Calabash::ABase

  def trait
    "* id:'message'"
  end

  def dismissDialog
    if element_exists "* id:'message'"
      touch "* text:'OK'"
    else
      touch "* text:'Yes'"
    end
    wait_for_elements_exist ["* marked:'cc_event_status_image'"]
  end

  def confe
    touch "* text:'Mobile Dev + Test Conference 2015'"
  end

end