class Seta extends Phaser.Physics.Arcade.Sprite
{
    constructor(scene,x,y)
    {
        super(scene,x+16,y-16,'tilesSprites',114);
        this.scene = scene;
        this.scene.add.existing(this);
        this.scene.physics.add.existing(this);
        this.body.allowGravity = false;
        
    }


    update(time,delta)
    {
        console.log('Seta');
        
    }
}

export default Seta;