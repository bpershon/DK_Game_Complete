import sys

if len(sys.argv) == 3:
	state_name = sys.argv[1]
	base_name = sys.argv[2]

	dk_template = open('dkTemplate.cs', 'r')
	dd_template = open('ddTemplate.cs', 'r')
	player_template = open('playerTemplate.cs', 'r')

	dk_string = dk_template.read()
	dd_string = dd_template.read()
	player_string = player_template.read()

	base_file_name = "PlayerBaseState"
	base_path = ""

	if base_name == "rambi":
		base_file_name += "Rambi"
		base_path = "/RambiStates/"

	if base_name == "barrel":
		base_file_name += "Barrel"
		base_path = "/BarrelStates/"

	if base_name == "regular":
		base_file_name += "Regular"
		base_path = "/RegularStates/"

	dk_file_name = "DK" + state_name + "State"
	dk_file_path = "States/DonkeyStates" + base_path + dk_file_name + ".cs"

	dd_file_name = "DD" + state_name + "State"
	dd_file_path = "States/DiddyStates" + base_path + dd_file_name + ".cs"

	player_file_name = "Player" + state_name + "State"
	player_file_path = "States/PlayerStates" + base_path + player_file_name + ".cs"

	dk_string = dk_string.replace("DK_FILE_NAME", dk_file_name).replace("PLAYER_FILE_NAME", player_file_name)
	dd_string = dd_string.replace("DD_FILE_NAME", dd_file_name).replace("PLAYER_FILE_NAME", player_file_name)
	player_string = player_string.replace("PLAYER_FILE_NAME", player_file_name).replace("BASE_STATE_NAME", base_file_name)

	dk_new = open("../"+dk_file_path, 'w')
	dd_new = open("../"+dd_file_path, 'w')
	player_new = open("../"+player_file_path, 'w')

	dk_new.write(dk_string)
	dd_new.write(dd_string)
	player_new.write(player_string)

	print ("\nAdd the following to the .csproj:\n")
	print ("<Compile Include=\""+dd_file_path.replace("/","\\")+"\" />")
	print ("<Compile Include=\""+dk_file_path.replace("/","\\")+"\" />")
	print ("<Compile Include=\""+player_file_path.replace("/","\\")+"\" />\n")

else:
	print ("\nAcceptable usage:\n\nstatecreator.py [StateName] [BaseName]\n\nWhere StateName is the name of the state, excluding the word 'State' and BaseName is either 'rambi', 'barrel', or 'regular'.\n")



