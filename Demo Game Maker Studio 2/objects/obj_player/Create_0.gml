/// @description Insert description here
// You can write your code in this editor

velocidad=3;
hp = obj_game_controller.player_data[? "hp"];

if(room == Room1){
//audio_play_sound(bgm_lights_out,0,true);
}
state = scr_state_dle;
h_dir = 1;
attack_sensor=  noone;

save_hp_to_controller = function (){

obj_game_controller.player_data[? "hp"] = hp;

}