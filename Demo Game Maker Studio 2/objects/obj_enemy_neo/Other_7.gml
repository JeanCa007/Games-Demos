/// @description Insert description here
// You can write your code in this editor
if(state == scr_enemy_neo_attack){
	
	var bullet = instance_create_layer(x+lengthdir_x(15,dir_x),y,"Instances",obj_enemy_ball);
	bullet.dir = point_direction(x,y,obj_player.x,obj_player.y);
	
	state = scr_enemy_neo_idle;
}