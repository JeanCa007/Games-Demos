class Win extends Phaser.Scene {

    constructor() {
        super({key: 'Win'});
    }
    init(data) {
        console.log('Scene Win');
        this.flagLose=data=='lose'?true:false;
    }
            
    create(flagLose) {
      
        this.add.image(0,0, 'Bg').setOrigin (0);
        this.add.image(150, 100, this.flagLose?'lose':'Win').setOrigin (0);
        this.playButton = this.add.image(310, 300, 'Btn_Menu').setOrigin(0);
       
        this.doInteractive();

        this.sound.stopAll('Sweet');
        this.sound.play ('Win')

    }


    update(time, delta) {
          
    }

    doInteractive(){

        this.playButton.setInteractive();
        this.playButton.on('pointerup',()=>{
            
            this.scene.start('Menu');
        })
    }
}

export default Win;