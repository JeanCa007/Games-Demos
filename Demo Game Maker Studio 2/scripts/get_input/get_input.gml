// Script assets have changed for v2.3.0 see
// https://help.yoyogames.com/hc/en-us/articles/360005277377 for more information
function scr_get_input(){
	
	if(gamepad_is_connected(0)){
		
		//Gamepad (control)
	right = gamepad_button_check(0,gp_padr);
	left = gamepad_button_check(0,gp_padl);
	up = gamepad_button_check(0,gp_padu);
	down = gamepad_button_check(0,gp_padd);
	attack = gamepad_button_check(0,gp_face3);
	pause = gamepad_button_check_pressed(0,gp_start);
	enter = gamepad_button_check_pressed(0,gp_face1);
	
	up_tap = gamepad_button_check_pressed(0,gp_padu);
	down_tap = gamepad_button_check_pressed(0,gp_padd);
	
	}else{	
		
		//keyboard input
	right =  keyboard_check(ord("D"));
	left =  keyboard_check(ord("A"));
	up =  keyboard_check(ord("W"));
	down =  keyboard_check(ord("S"));
	attack = keyboard_check(ord("J"));
	pause = keyboard_check_released(vk_escape); //esto sucede solo cuando suelto la tecla
	enter = keyboard_check_released(vk_enter);
	
	up_tap =   keyboard_check_released(ord("W"));
	down_tap =   keyboard_check_released(ord("S"));
	
	}

}