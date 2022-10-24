/// @description Insert description here
// You can write your code in this editor
draw_sprite_ext(spr_batman_attack,1,display_get_gui_width()/2-150,display_get_gui_height()/2-50,4,4,0,c_white,1);

draw_text_ext_transformed_color(display_get_gui_width()/2-150,display_get_gui_height()/2-50,"4Studios",0,100,8,8,0,c_red,c_red,c_red,c_red,1);

if(fade_out){
	draw_set_alpha(current_alpha);
	draw_rectangle_color(0,0,display_get_gui_width(),display_get_gui_height(),c_black,c_black,c_black,c_black,false);
	draw_set_alpha(1);
	
	current_alpha += 0.5;
	
	if(current_alpha <=1){
		
		
		room_goto_next();
	
	}
}