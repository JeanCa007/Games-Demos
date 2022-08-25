class Menu extends Phaser.Scene {
    constructor() {
        super({key: 'Menu'});
    }
    init() {
        console.log('Scene MainMenu');
       
        
    }
            
    create() {
       
        this.sound.play('Sweet', {
            loop:true
        })
        this.add.image(0,0, 'Bg').setOrigin (0);
        this.add.image(150, 100, 'Titulo').setOrigin (0);
        let playButton = this.add.image(310, 300, 'Btn_Play').setOrigin (0);
        playButton.setInteractive();

        
        playButton.on('pointerup',()=>{
            console.log('MainScene');
            this.scene.start('MainScene');
        })

    }
    
}

export default Menu;