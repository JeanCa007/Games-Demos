/// @description Insert description here
// You can write your code in this editor
if(state == scr_state_attack){
	
	if(attack_sensor != noone){
		instance_destroy(attack_sensor);
	}
	
	
	state = scr_state_dle;

}