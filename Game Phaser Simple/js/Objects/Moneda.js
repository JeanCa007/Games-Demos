class Moneda extends Phaser.Physics.Arcade.StaticGroup {
    constructor(config) {
        super(config.physicsWorld, config.scene);        
        this.addTomatoItem();
    }

    addTomatoItem() {

        let x=100;
        let y=200;
        for (let i = 0; i < 6; i++) {
            
            this.create(
                x,
                y,
                'moneda'
            );

            x+=150;
            
        }
        
    }

    destroyItem() {
        this.children.entries[0].destroy();
        
    }

}

export default Moneda;