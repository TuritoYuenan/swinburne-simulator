extends BoxContainer

func _on_start_button_pressed():
	get_tree().change_scene_to_file("res://Campus/Floor9.tscn")

func _on_credits_button_pressed():
	get_tree().change_scene_to_file("res://Interfaces/Credits.tscn")

func _on_code_button_pressed():
	OS.shell_open("https://github.com/TuritoYuenan/swinburne-simulator")

func _on_back_button_pressed():
	get_tree().change_scene_to_file("res://Interfaces/MainMenu.tscn")
