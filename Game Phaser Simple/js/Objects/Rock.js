class Rock extends Phaser.Physics.Arcade.Sprite {
    constructor(scene,x,y) {
        super(scene,x,y,'rock');
        this.scene = scene;
        this.scene.add.existing(this);
        this.scene.physics.add.existing(this);
        this.body.allowGravity = true;
        this.body.setBounce(1);
        this.body.setCircle(15);
    }
}

export default Rock;