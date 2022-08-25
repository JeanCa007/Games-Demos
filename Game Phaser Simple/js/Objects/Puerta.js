class Puerta extends Phaser.Physics.Arcade.Sprite {
    constructor(scene,x,y) {
        super(scene,x,y,'Puerta');
        this.scene = scene;
        this.scene.add.existing(this);
        this.scene.physics.add.existing(this);
        
        this.setScale(0.7);

    }

    win(){

        this.scene.registry.events.emit('win');
    }

}

export default Puerta;