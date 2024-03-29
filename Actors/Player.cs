﻿using MartinMatta_MerlinCore.Actors.Interfaces;
using MartinMatta_MerlinCore.Commands;
using MartinMatta_MerlinCore.Items;
using MartinMatta_MerlinCore.Spells;
using MartinMatta_MerlinCore.Spells.Interfaces;
using MartinMatta_MerlinCore.Spells.Passives;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using Merlin2d.Game.Items;

namespace MartinMatta_MerlinCore.Actors
{
    public class Player : AbstractWizardCharacter
    {
        private Animation animation;

        private int intersectCounter;
        private int speedUpCounter;
        private int passivesCounter;
        private int lastY;

        private NormalSpeedStrategy normalSpeedStrategy;
        private ModifiedSpeedStrategy modifiedSpeedStrategy;

        private bool canJump;
        private bool hasShownHelp;
        private bool hasStarted;
        
        private IMovement moveUp;
        private IMovement moveDown;
        private IMovement moveRight;
        private IMovement moveLeft;
        private Jump<IActor> jump;

        private ISpellDirector spellDirector;

        private Backpack inventory;

        private IMessage status;
        private IMessage help;

        public Player(int x, int y, double speed)
        {
            this.status = new Message($"{this.GetHealth()}, {this.GetMana()}", 0, -30, 15, Color.Orange, MessageDuration.Indefinite);
            this.help = new Message("Use arrows for movement.\n" +
                                    "Press Q to cast a damaging spell.\n" +
                                    "Press W to self heal and boost your athleticism briefly.\n" +
                                    "Press E to pick up or use items, fill potions,\n" +
                                    "use the teleporter and hold boxes.\n" +
                                    "Using the semicolon and apostrophe you can switch\n" +
                                    "between items in inventory.\n" +
                                    "Destroy all the spawners and kill all the skeletons\n" +
                                    "in the Ancient Ancestor's Cave.\n" +
                                    "Good luck, 47."
                                    , 700, 100, 30, Color.Orange, MessageDuration.Indefinite);

            this.SetPosition(x, y);

            this.intersectCounter = 0;
            this.speedUpCounter = 0;
            this.passivesCounter = 0;
            /*this.ChangeHealth(-90);
            this.ChangeMana(-90);*/
            this.hasShownHelp = false;
            this.hasStarted = false;

            this.spellDirector = new SpellDirector(this);

            this.speed = speed;
            this.normalSpeedStrategy = new NormalSpeedStrategy();
            this.modifiedSpeedStrategy = new ModifiedSpeedStrategy();
            this.strategy = this.normalSpeedStrategy;

            this.animation = new Animation("resources/sprites/player.png", 28, 47);
            this.SetAnimation(animation);
            this.GetAnimation().Start();

            Console.WriteLine("speed");
            Console.WriteLine(this.speed);

            //this.moveUp = new Move(this, 0, -1);
            //this.moveDown = new Move(this, 0, 1);
            this.moveRight = new Move(this, 1, 0);
            this.moveLeft = new Move(this, -1, 0);
            this.jump = new Jump<IActor>(this, 220);
            this.orientation = ActorOrientation.RIGHT;
            this.lastY = 0;
            this.passives.Add(new HealthRechargeEffect(this));
            this.passives.Add(new ManaRechargeEffect(this));
            this.inventory = new Backpack(4);
        }

        public Backpack GetInvetory()
        {
            return this.inventory;
        }

        public bool HasStarted()
        {
            return this.hasStarted;
        }

        public override void Update()
        {
            if (!this.hasShownHelp)
            {
                this.GetWorld().AddMessage(this.help);
                CatSword cat = new CatSword(this);
                cat.OnAddedToWorld(this.GetWorld());
                this.inventory.AddItem(cat);
                this.hasShownHelp = true;
            }
            if(!this.hasStarted && (Input.GetInstance().IsKeyDown(Input.Key.LEFT) || Input.GetInstance().IsKeyDown(Input.Key.RIGHT) || Input.GetInstance().IsKeyDown(Input.Key.UP)) )
            {
                this.GetWorld().RemoveMessage(this.help);
                this.hasStarted = true;
            }

            this.GetWorld().RemoveMessage(this.status);
            this.status = new Message($"{this.GetHealth()}, {this.GetMana()}", -10, -15, 15, Color.Orange, MessageDuration.Indefinite);
            this.status.SetAnchorPoint(this);
            this.GetWorld().AddMessage(this.status);
            //Console.WriteLine(this.speed);
            Console.WriteLine(this.GetHealth());
            Console.WriteLine(this.GetMana());
            //Console.WriteLine(this.strategy);
            this.GetWorld().ShowInventory(this.inventory);
            List<IActor> enemies = this.GetWorld().GetActors().FindAll(x => x.GetName() == "Spooky Scary Skeleton");
            if(this.GetHealth() > 0)
            {
                passivesCounter++;
                if(passivesCounter == 90)
                {
                    foreach(ICommand passiveItem in this.passives)
                    {
                        passiveItem.Execute();
                    }
                    this.passivesCounter = 0;
                }
                if (this.strategy is SpeedUpSpeedStrategy)
                {
                    if (this.speedUpCounter == 180)
                    {
                        this.speedUpCounter = 0;
                        this.strategy = this.normalSpeedStrategy;
                    }
                    this.speedUpCounter++;
                }
                else
                {
                    if (enemies.Count() != 0)
                    {
                        foreach(IActor enemyItem in enemies)
                        {
                            if (this.IntersectsWithActor(enemyItem))
                            {
                                //Console.WriteLine("intersects");
                                if (this.intersectCounter == 5)
                                {
                                    this.intersectCounter = 0;
                                    this.ChangeHealth(-5);
                                }
                                this.intersectCounter++;
                                this.strategy = this.modifiedSpeedStrategy;
                            }
                            else
                            {
                                this.strategy = this.normalSpeedStrategy;
                            }
                        }
                    }
                    else
                    {
                        this.strategy = this.normalSpeedStrategy;
                    }
                }
                if (Input.GetInstance().IsKeyDown(Input.Key.UP) && this.canJump)
                {
                    this.canJump = false;
                    animation.Start();
                    //this.moveUp.Execute();
                    this.jump.Execute(this);
                }

                else if (Input.GetInstance().IsKeyDown(Input.Key.RIGHT))
                {
                    if (this.orientation == ActorOrientation.LEFT)
                        animation.FlipAnimation();
                    animation.Start();
                    this.moveRight.Execute();
                    this.orientation = ActorOrientation.RIGHT;
                }
                else if (Input.GetInstance().IsKeyDown(Input.Key.LEFT))
                {
                    if (this.orientation == ActorOrientation.RIGHT)
                        animation.FlipAnimation();
                    animation.Start();
                    this.moveLeft.Execute();
                    this.orientation = ActorOrientation.LEFT;
                }
                else
                {
                    animation.Stop();
                }

                this.Using();

                if (!this.canJump && this.lastY == this.GetY())
                {
                    this.canJump = true;
                }
                else if(this.lastY != this.GetY())
                {
                    this.canJump = false;
                }
                this.lastY = this.GetY();
            }
            else
            {
                this.Die();
            } 
        }

        private void Using()
        {
            if (Input.GetInstance().IsKeyPressed(Input.Key.W))
            {
                ISpell spell = this.spellDirector.Build("Into the Fray!");
                if (spell != null)
                    spell.ApplyEffects(this);
            }
            else if (Input.GetInstance().IsKeyPressed(Input.Key.Q))
            {
                this.spellDirector.Build("icicle");
            }
            else if (Input.GetInstance().IsKeyPressed(Input.Key.E))
            {
                List<IActor> stations = this.GetWorld().GetActors().Where(a => a is IStation).ToList();
                foreach (IActor station in stations)
                {
                    if (this.IntersectsWithActor(station))
                    {
                        (station as IStation).Use(this);
                        return;
                    }
                }
                List<IActor> teleporters = this.GetWorld().GetActors().Where(a => a is Teleporter).ToList();
                foreach (Teleporter teleporter in teleporters)
                {
                    if (this.IntersectsWithActor(teleporter))
                    {
                        teleporter.Use(this);
                        return;

                    }
                }

                if (!this.inventory.IsFull())
                {
                    List<IActor> items = this.GetWorld().GetActors().Where(a => a is IItem).ToList();
                    foreach (IActor item in items)
                    {
                        if (this.IntersectsWithActor(item))
                        {
                            if(item is CatSword && !(item as CatSword).IsInUse())
                            {
                                this.inventory.AddItem((item as IItem));
                                item.RemoveFromWorld();
                                return;
                            }
                        }
                    }
                }
                if (this.inventory.GetItem() != null)
                {
                    (this.inventory.GetItem() as IUsable)?.Use(this);
                    if (this.inventory.GetItem() is Jar)
                    {
                        this.inventory.ReplaceItemAtIndex(0, new Jar().SetWorld(this.GetWorld()));
                    }
                    //else if (this.inventory.GetItem() is CatSword) { }
                }
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.E))
            {
                List<IActor> boxes = this.GetWorld().GetActors().Where(a => a is Box).ToList();
                foreach (Box box in boxes)
                {
                    if (box.IsActorLeft())
                    {
                        box.SetPosition(this.GetX() + this.GetWidth() + 1, this.GetY());
                    }
                    else if (box.IsActorRight())
                    {
                        box.SetPosition(this.GetX() - box.GetWidth() - 1, this.GetY());
                    }
                }
            }
            else if (Input.GetInstance().IsKeyPressed(Input.Key.R))
            {
                IItem item = this.inventory.GetItem();
                if (item != null)
                {
                    (item as AbstractActor).ReturnToWorld();
                    item.SetPosition(this.GetX() + this.GetWidth() / 2, this.GetY() + this.GetHeight() / 2);
                    this.inventory.RemoveItem(0);
                    this.inventory.ShiftLeft();
                    item.SetPhysics(true);
                }
            }
            else if (Input.GetInstance().IsKeyPressed(Input.Key.SEMICOLON))
            {
                this.inventory.ShiftRight();
            }
            else if (Input.GetInstance().IsKeyPressed(Input.Key.APOSTROPHE))
            {
                this.inventory.ShiftLeft();
            }
        }
    }
}
