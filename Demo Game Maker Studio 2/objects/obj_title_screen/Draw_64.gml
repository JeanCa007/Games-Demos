/// @description Insert description here
// You can write your code in this editor

draw_set_halign(fa_center);
draw_text_ext_transformed_color(display_get_gui_width()/2,100,"My Game !!",10,100,5,5,0,c_white,c_white,c_white,c_white,1);

if(selected_option == 0){
 
 var continue_color = c_yellow;
 var restart_color = c_white;
 var credits_color = c_white;
 
 
}else if(selected_option == 1){
	
 var continue_color = c_white;
 var restart_color = c_white ;
 var credits_color = c_yellow;
	
}else if(selected_option == 2){
	
 var continue_color = c_white;
 var restart_color = c_yellow ;
 var credits_color = c_white;
	
}



if(file_exitance){
	
	var firts_option = "Continue";

}else{
	
	var firts_option = "New Game";

}

draw_text_ext_transformed_color(display_get_gui_width()/2,250,firts_option,10,100,3,3,0,continue_color,continue_color,continue_color,continue_color,1);
draw_text_ext_transformed_color(display_get_gui_width()/2,300,"Credits",10,100,3,3,0,credits_color,credits_color,credits_color,credits_color,1);
draw_text_ext_transformed_color(display_get_gui_width()/2,350,"Exit",10,100,3,3,0,restart_color,restart_color,restart_color,restart_color,1);

draw_set_halign(fa_left);