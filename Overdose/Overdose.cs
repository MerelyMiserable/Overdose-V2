using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Overdose
{
    public class Overdose
    {
        public static void Main()
        {
            ModAPI.RegisterLiquid(FireSyringe.FireSerum.ID, new FireSyringe.FireSerum());
            ModAPI.RegisterLiquid(ElecSyringe.ElecSerum.ID, new ElecSyringe.ElecSerum());
            ModAPI.RegisterLiquid(BetterSyringe.BetterSerum.ID, new BetterSyringe.BetterSerum());
            ModAPI.RegisterLiquid(OuchSyringe.OuchSerum.ID, new OuchSyringe.OuchSerum());
            ModAPI.RegisterLiquid(AntigravitySyringe.AntigravitySerum.ID, new AntigravitySyringe.AntigravitySerum());
            ModAPI.RegisterLiquid(SpazSyringe.SpazSerum.ID, new SpazSyringe.SpazSerum());
            ModAPI.RegisterLiquid(LSSyringe.LSSerum.ID, new LSSyringe.LSSerum());
            ModAPI.RegisterLiquid(KabooieSyringe.KabooieSerum.ID, new KabooieSyringe.KabooieSerum());
            ModAPI.RegisterLiquid(RNSyringe.RNSerum.ID, new RNSyringe.RNSerum());
            ModAPI.RegisterLiquid(FPSyringe.FPSerum.ID, new FPSyringe.FPSerum());
            ModAPI.RegisterLiquid(NESyringe.NESerum.ID, new NESyringe.NESerum());


            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Generator"),
                    NameOverride = "Gray's Generator-OD",
                    NameToOrderByOverride = "Generator 2",
                    DescriptionOverride = "A Generator but made by florida man.",
                    CategoryOverride = ModAPI.FindCategory("Machinery"),
                    ThumbnailOverride = ModAPI.LoadSprite("grayView.png"),
                    AfterSpawn = (Instance) =>
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("gray.png");
                        Instance.transform.localScale = new Vector2(1f, 1f);
                        Instance.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 1f;
                        Instance.AddComponent<GeneratorBehaviour>();
                        UseEventTrigger useEventTrigger = Instance.AddComponent<UseEventTrigger>();
                        useEventTrigger.Event = new UnityEvent();
                        useEventTrigger.Event.AddListener(delegate ()
                        {
                            Instance.GetComponent<PhysicalBehaviour>().charge = float.PositiveInfinity;
                            Instance.GetComponent<PhysicalBehaviour>().Charge = float.PositiveInfinity;
                        });
                    }
                }
            );

            {
                ModAPI.Register(
                    new Modification()
                    {
                        OriginalItem = ModAPI.FindSpawnable("Life Syringe"),
                        NameOverride = "Fire Syringe-OD",
                        NameToOrderByOverride = "Syringe 99",
                        DescriptionOverride = "Injection of this syringe causes combustion.",
                        CategoryOverride = ModAPI.FindCategory("Biohazard"),
                        ThumbnailOverride = ModAPI.LoadSprite("ignsyringView.png"),
                        AfterSpawn = (Instance) =>
                        {
                            UnityEngine.Object.Destroy(Instance.GetComponent<SyringeBehaviour>());
                            Instance.GetOrAddComponent<FireSyringe>();
                        }
                    }
                );


                ModAPI.Register(
                            new Modification()
                            {
                                OriginalItem = ModAPI.FindSpawnable("Life Syringe"),
                                NameOverride = "Electricity Syringe-OD",
                                NameToOrderByOverride = "Syringe 999",
                                DescriptionOverride = "Injection of this syringe electrifies the victim.",
                                CategoryOverride = ModAPI.FindCategory("Biohazard"),
                                ThumbnailOverride = ModAPI.LoadSprite("elecsyringView.png"),
                                AfterSpawn = (Instance) =>
                                {
                                    UnityEngine.Object.Destroy(Instance.GetComponent<SyringeBehaviour>());
                                    Instance.GetOrAddComponent<ElecSyringe>();
                                }
                            }
                        );

                ModAPI.Register(
        new Modification()
        {
            OriginalItem = ModAPI.FindSpawnable("Life Syringe"),
            NameOverride = "Better Syringe-OD",
            NameToOrderByOverride = "Syringe 9999",
            DescriptionOverride = "Injection of this syringe makes the victim better.",
            CategoryOverride = ModAPI.FindCategory("Biohazard"),
            ThumbnailOverride = ModAPI.LoadSprite("bettersyringView.png"),
            AfterSpawn = (Instance) =>
            {
                UnityEngine.Object.Destroy(Instance.GetComponent<SyringeBehaviour>());
                Instance.GetOrAddComponent<BetterSyringe>();
            }
        }
    );
            

                ModAPI.Register(
                    new Modification()
                    {
                        OriginalItem = ModAPI.FindSpawnable("Revolver"),
                        NameOverride = "Florida Man's Gun-OD",
                        NameToOrderByOverride = "Revolver 2",
                        DescriptionOverride = "PEW PEW BANG BANG",
                        CategoryOverride = ModAPI.FindCategory("Firearms"),
                        ThumbnailOverride = ModAPI.LoadSprite("perngView.png", 5f),
                        AfterSpawn = (Instance) =>
                        {
                            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("perng.png");
                            var firearm = Instance.GetComponent<FirearmBehaviour>();
                            Cartridge customCartridge = ModAPI.FindCartridge("9mm");
                            customCartridge.name = "DEATH";
                            customCartridge.Damage += 999999f;
                            customCartridge.Recoil += 999999f;
                            firearm.Cartridge = customCartridge;
                        }
                    }
                );

                ModAPI.Register(
                 new Modification()
                 {
                     OriginalItem = ModAPI.FindSpawnable("Revolver"),
                     NameOverride = "anti gun-OD",
                     NameToOrderByOverride = "Revolver 3",
                     DescriptionOverride = "so Like does it heal people?",
                     CategoryOverride = ModAPI.FindCategory("Firearms"),
                     ThumbnailOverride = ModAPI.LoadSprite("antigunView.png", 5f),
                     AfterSpawn = (Instance) =>
                     {
                         Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("antigun.png");
                         var firearm = Instance.GetComponent<FirearmBehaviour>();
                         Cartridge customCartridge = ModAPI.FindCartridge("9mm");
                         customCartridge.name = "life?";
                         customCartridge.Damage += -999999f;
                         customCartridge.Recoil += -10f;
                         firearm.Cartridge = customCartridge;
                     }
                 }
                 );

                ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Life Syringe"),
                    NameOverride = "Outtahere Syringe-OD",
                    NameToOrderByOverride = "Syringe 9999999",
                    DescriptionOverride = "ight imma head out.",
                    CategoryOverride = ModAPI.FindCategory("Biohazard"),
                    ThumbnailOverride = ModAPI.LoadSprite("outtahereView.png"),
                    AfterSpawn = (Instance) =>
          {
              UnityEngine.Object.Destroy(Instance.GetComponent<SyringeBehaviour>());
              Instance.GetOrAddComponent<AntigravitySyringe>();
          }
                }
                );

              //  ModAPI.Register(
              //  new Modification()
              //  {
              //      OriginalItem = ModAPI.FindSpawnable("Life Syringe"),
              //      NameOverride = "Spaz Syringe-OD",
              //      NameToOrderByOverride = "Syringe 999999999",
              //      DescriptionOverride = "Makes the limb you inject it into spaz out " +
              //      "EHEHHEHEHEHEHEAHHH.",
              //      CategoryOverride = ModAPI.FindCategory("Biohazard"),
              //      ThumbnailOverride = ModAPI.LoadSprite("spazsyringView.png"),
              //      AfterSpawn = (Instance) =>
              //      {
              //          UnityEngine.Object.Destroy(Instance.GetComponent<SyringeBehaviour>());
              //          Instance.GetOrAddComponent<SpazSyringe>();
              //      }
              //  }
              //  );

                ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Life Syringe"),
        NameOverride = "Kabooie Syringe-OD",
        NameToOrderByOverride = "Syringe 99999999",
        DescriptionOverride = "Aye, me bottle o' scrumpy!",
        CategoryOverride = ModAPI.FindCategory("Biohazard"),
        ThumbnailOverride = ModAPI.LoadSprite("kabooiesyringView.png"),
        AfterSpawn = (Instance) =>
        {
            UnityEngine.Object.Destroy(Instance.GetComponent<SyringeBehaviour>());
            Instance.GetOrAddComponent<KabooieSyringe>();
        }
    }
);


                ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Life Syringe"),
        NameOverride = "Life Steal Syringe-OD",
        NameToOrderByOverride = "Syringe 999999999",
        DescriptionOverride = "zucc",
        CategoryOverride = ModAPI.FindCategory("Biohazard"),
        ThumbnailOverride = ModAPI.LoadSprite("lssyringView.png"),
        AfterSpawn = (Instance) =>
        {
            UnityEngine.Object.Destroy(Instance.GetComponent<SyringeBehaviour>());
            Instance.GetOrAddComponent<LSSyringe>();
        }
    }
);

    ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Life Syringe"),
        NameOverride = "Risotto Nero Syringe-OD",
        NameToOrderByOverride = "Syringe 9999999999",
        DescriptionOverride = "I can't wait to see the look on your face as you die! I win! I'll send your head flying!",
        CategoryOverride = ModAPI.FindCategory("Biohazard"),
        ThumbnailOverride = ModAPI.LoadSprite("rssyringView.png"),
        AfterSpawn = (Instance) =>
        {
            UnityEngine.Object.Destroy(Instance.GetComponent<SyringeBehaviour>());
            Instance.GetOrAddComponent<RNSyringe>();
        }
    }
);
    ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Life Syringe"),
        NameOverride = "Flesh Poison Syringe-OD",
        NameToOrderByOverride = "Syringe 99999999999",
        DescriptionOverride = "man this rash sucks",
        CategoryOverride = ModAPI.FindCategory("Biohazard"),
        ThumbnailOverride = ModAPI.LoadSprite("fpsyringView.png"),
        AfterSpawn = (Instance) =>
        {
            UnityEngine.Object.Destroy(Instance.GetComponent<SyringeBehaviour>());
            Instance.GetOrAddComponent<FPSyringe>();
        }
    }
);

    ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Life Syringe"),
        NameOverride = "Necrosis Syringe-OD",
        NameToOrderByOverride = "Syringe 999999999999",
        DescriptionOverride = "uh oh",
        CategoryOverride = ModAPI.FindCategory("Biohazard"),
        ThumbnailOverride = ModAPI.LoadSprite("NSThumbView.png"),
        AfterSpawn = (Instance) =>
        {
            UnityEngine.Object.Destroy(Instance.GetComponent<SyringeBehaviour>());
            Instance.GetOrAddComponent<NESyringe>();
        }
    }
);



                ModAPI.Register(
                 new Modification()
                 {
                     OriginalItem = ModAPI.FindSpawnable("Revolver"),
                     NameOverride = "boom gun-OD",
                     NameToOrderByOverride = "Revolver 4",
                     DescriptionOverride = "BOOM BOOM BOOM",
                     CategoryOverride = ModAPI.FindCategory("Firearms"),
                     ThumbnailOverride = ModAPI.LoadSprite("boomView.png", 5f),
                     AfterSpawn = (Instance) =>
                     {
                         Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("boom.png");
                         var firearm = Instance.GetComponent<FirearmBehaviour>();
                         Cartridge customCartridge = ModAPI.FindCartridge("9mm");
                         customCartridge.name = "nuke";
                         customCartridge.Damage += -0.0000001f;
                         customCartridge.Recoil += 10f;
                         firearm.Cartridge = customCartridge;
                         Instance.AddComponent<Nukegun>();
                     }
                 }
                 );


                ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Dynamite"),
        NameOverride = "Anti Dynamite-OD",
        NameToOrderByOverride = "Dynamite",
        DescriptionOverride = "so a implosion?",
        CategoryOverride = ModAPI.FindCategory("Explosives"),
        ThumbnailOverride = ModAPI.LoadSprite("antibombView.png"),
        AfterSpawn = (Instance) =>
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("antibomb.png");
            Instance.GetComponent<SpriteRenderer>().color = Color.white;
            GameObject.Destroy(Instance.GetComponent<ExplosiveBehaviour>());
            Instance.AddComponent<antibomb>();
        }
    }
);



                ModAPI.Register(
                 new Modification()
                 {
                     OriginalItem = ModAPI.FindSpawnable("Revolver"),
                     NameOverride = "worp gun-OD",
                     NameToOrderByOverride = "Revolver 4",
                     DescriptionOverride = "THATS A LOT A DAMAGE!",
                     CategoryOverride = ModAPI.FindCategory("Firearms"),
                     ThumbnailOverride = ModAPI.LoadSprite("worpgunView.png", 5f),
                     AfterSpawn = (Instance) =>
                     {
                         Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("worpgun.png");
                         var firearm = Instance.GetComponent<FirearmBehaviour>();
                         Cartridge customCartridge = ModAPI.FindCartridge("9mm");
                         customCartridge.name = "blackhole";
                         customCartridge.Damage += -0.0000001f;
                         customCartridge.Recoil += 10f;
                         firearm.Cartridge = customCartridge;
                         Instance.AddComponent<Worpgun>();
                     }
                 }
                 );

                ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Decimator"),
                    NameOverride = "Spawnable Blackhole-OD",
                    NameToOrderByOverride = "Revolver 4",
                    DescriptionOverride = "Portable put it in your lunchbox!",
                    CategoryOverride = ModAPI.FindCategory("Firearms"),
                    ThumbnailOverride = ModAPI.LoadSprite("blackholeView.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        GameObject.Instantiate(ModAPI.FindSpawnable("Decimator").Prefab.GetComponent<DecimatorBehaviour>().BlackHole, Instance.transform.position, Quaternion.identity);
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("blackhole.png");
                        Instance.GetComponent<SpriteRenderer>().color = Color.clear;
                        UnityEngine.Object.Destroy(Instance.transform.GetChild(0).gameObject);
                        UnityEngine.Object.Destroy(Instance.transform.GetChild(1).gameObject);
                        UnityEngine.Object.Destroy(Instance.transform.GetChild(2).gameObject);
                        UnityEngine.Object.Destroy(Instance.transform.GetChild(3).gameObject);
                        UnityEngine.Object.Destroy(Instance.transform.GetChild(4).gameObject);
                        BoxCollider2D[] colliders = Instance.GetComponents<BoxCollider2D>();
                        for (int i = 0; i < colliders.Length; i++)
                        {
                            UnityEngine.GameObject.Destroy(colliders[i]);
                        }
                    }
                }
);

                ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Vector"),
                    NameOverride = "Flordia Man's Minigun-OD",
                    NameToOrderByOverride = "Revolver 5",
                    DescriptionOverride = "PEW PEW BANG BANG but cooler B)",
                    CategoryOverride = ModAPI.FindCategory("Firearms"),
                    ThumbnailOverride = ModAPI.LoadSprite("miniflorView.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("miniflor.png");
                        Instance.FixColliders();
                        var firearm = Instance.GetComponent<FirearmBehaviour>();
                        Cartridge customCartridge = ModAPI.FindCartridge("9mm");
                        customCartridge.name = "DEATH";
                        customCartridge.Damage += 999999f;
                        customCartridge.Recoil += 999999f;
                        customCartridge.ImpactForce += 999999f;
                        firearm.Cartridge = customCartridge;
                    }
                }
                );


                ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Shotgun"),
                    NameOverride = "Flordia Man's Shotgun-OD",
                    NameToOrderByOverride = "Revolver 6",
                    DescriptionOverride = "The Most Flordia Man of them all",
                    CategoryOverride = ModAPI.FindCategory("Firearms"),
                    ThumbnailOverride = ModAPI.LoadSprite("fmsgView.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("fmsg.png", 4f);
                        Instance.FixColliders();
                        var firearm = Instance.GetComponent<FirearmBehaviour>();
                        Cartridge customCartridge = ModAPI.FindCartridge("9mm");
                        customCartridge.name = "DEATH";
                        customCartridge.Damage += 9999999f;
                        customCartridge.Recoil += 9999999f;
                        customCartridge.ImpactForce += 9999999f;
                        firearm.Cartridge = customCartridge;
                    }
                }
            );
                ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Brick"),
                    NameOverride = "Overdose Legacy",
                    NameToOrderByOverride = "brick 2",
                    DescriptionOverride = "Activate me for Overdose Legacy",
                    CategoryOverride = ModAPI.FindCategory("Misc."),
                    ThumbnailOverride = ModAPI.LoadSprite("OverdoseL.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var trigger = Instance.AddComponent<UseEventTrigger>();
                        trigger.Event = new UnityEngine.Events.UnityEvent();
                        trigger.Event.AddListener(delegate ()
                        {
                            Utils.OpenURL("https://steamcommunity.com/sharedfiles/filedetails/?id=2577756777");
                        });
                    }
          });
        }
    }

    public class FireSyringe : SyringeBehaviour
    {
        public override string GetLiquidID() => FireSerum.ID;

        public class FireSerum : Liquid
        {
            public const string ID = "FIRE SERUM-OD";

            public FireSerum()
            {
                Color = new UnityEngine.Color(0.89f, 0.11f, 0.11f, 1);
            }

            public override void OnEnterLimb(LimbBehaviour limb)
            {
                limb.PhysicalBehaviour.Ignite(true);
            }

            public override void OnUpdate(BloodContainer container) 
            {
                base.OnUpdate(container);
            }
            public override void OnEnterContainer(BloodContainer container) { }
            public override void OnExitContainer(BloodContainer container) { }
        };
    }

    }

public class ElecSyringe : SyringeBehaviour
{
    public override string GetLiquidID() => ElecSerum.ID;

    public class ElecSerum : Liquid
    {
        public const string ID = "ELECTRIC SERUM-OD";

        public ElecSerum()
        {
            Color = new UnityEngine.Color(0.1f, 0f, 1f, 1);
        }

        public override void OnEnterLimb(LimbBehaviour limb)
        {
            limb.PhysicalBehaviour.charge = 50f;
        }

        public override void OnUpdate(BloodContainer container) { base.OnUpdate(container); }
        public override void OnEnterContainer(BloodContainer container) { }
        public override void OnExitContainer(BloodContainer container) { }
    };

    }

public class BetterSyringe : SyringeBehaviour
{
    public override string GetLiquidID() => BetterSerum.ID;

    public class BetterSerum : Liquid
    {
        public const string ID = "BETTER SERUM-OD";

        public BetterSerum()
        {
            Color = new UnityEngine.Color(1f, 0.75f, 0.9f, 1);
        }

        public override void OnEnterLimb(LimbBehaviour limb)
        {
            limb.HealBone();
            limb.Health = 2147483647f;
            limb.Numbness = -2147483647f;
            limb.CirculationBehaviour.HealBleeding();
            limb.CirculationBehaviour.IsPump = limb.CirculationBehaviour.WasInitiallyPumping;
            limb.CirculationBehaviour.BloodFlow = 100f;
            limb.CirculationBehaviour.BloodAmount = 100f;
            limb.BruiseCount = (ushort)0;
            limb.CirculationBehaviour.GunshotWoundCount = (ushort)0;
            limb.CirculationBehaviour.StabWoundCount = (ushort)0;
            limb.Vitality *= 0.1f;
            limb.RegenerationSpeed += 2147483647f;
            limb.ImpactPainMultiplier *= 2147483647f;
            limb.InitialHealth += 2147483647f;
            limb.Health = limb.InitialHealth;
            limb.BreakingThreshold += 2147483647f;
            limb.BaseStrength += 5;
            limb.ShotDamageMultiplier = Math.Max(0f, limb.ShotDamageMultiplier - 2147483647f);
            limb.Wince(float.MaxValue);
            if (limb.RoughClassification == LimbBehaviour.BodyPart.Head)
            {
                limb.Person.Consciousness = 2147483647f;
                limb.Person.ShockLevel = -2147483647f;
                limb.Person.PainLevel = -2147483647f;
                limb.Person.OxygenLevel = 2147483647f;
                limb.Person.AdrenalineLevel = 2147483647f;
            }
        }

        public override void OnUpdate(BloodContainer container) { base.OnUpdate(container); }
        public override void OnEnterContainer(BloodContainer container) { }
        public override void OnExitContainer(BloodContainer container) { }
    };

}

        public class OuchSyringe : SyringeBehaviour
        {
            public override string GetLiquidID() => OuchSerum.ID;

            public class OuchSerum : Liquid
            {
                public const string ID = "OUCH SERUM-OD";

                public OuchSerum()
                {
                    Color = new UnityEngine.Color(0.45f, 0f, 0.66f, 1);
                }

                public override void OnEnterLimb(LimbBehaviour limb)
                {
            limb.Health = -2147483647f;
            limb.Numbness = 2147483647f;
            limb.CirculationBehaviour.BloodFlow = -100f;
            limb.CirculationBehaviour.BloodAmount = -100f;
            limb.BruiseCount = (ushort)0;
            limb.CirculationBehaviour.GunshotWoundCount = (ushort)65535;
            limb.CirculationBehaviour.StabWoundCount = (ushort)65535;
            limb.Vitality *= -0.1f;
            limb.RegenerationSpeed += -2147483647f;
            limb.ImpactPainMultiplier *= -2147483647f;
            limb.InitialHealth += -2147483647f;
            limb.Health = limb.InitialHealth;
            limb.BreakingThreshold += -2147483647f;
            limb.BaseStrength += -5;
            limb.ShotDamageMultiplier = Math.Max(0f, limb.ShotDamageMultiplier - -2147483647f);
            limb.Wince(float.MaxValue);
            if (limb.RoughClassification == LimbBehaviour.BodyPart.Head)
            {
                limb.Person.Consciousness = -2147483647f;
                limb.Person.ShockLevel = 2147483647f;
                limb.Person.PainLevel = 2147483647f;
                limb.Person.OxygenLevel = -2147483647f;
                limb.Person.AdrenalineLevel = -2147483647f;
            }

        }

                public override void OnUpdate(BloodContainer container) { base.OnUpdate(container); }
                public override void OnEnterContainer(BloodContainer container) { }
                public override void OnExitContainer(BloodContainer container) { }

            };
        }

public class AntigravitySyringe : SyringeBehaviour
{
    public override string GetLiquidID() => AntigravitySerum.ID;

    public class AntigravitySerum : Liquid
    {
        public const string ID = "AntiGrav SERUM-OD";

        public AntigravitySerum()
        {
            Color = new UnityEngine.Color(0.51f, 0.51f, 0.51f, 1);
        }

        public override void OnEnterLimb(LimbBehaviour limb)
        {
          limb.PhysicalBehaviour.rigidbody.gravityScale = -1f;
        }

        public override void OnUpdate(BloodContainer container) { }
        public override void OnEnterContainer(BloodContainer container) { }
        public override void OnExitContainer(BloodContainer container) { }

    }
}
public class SpazSyringe : SyringeBehaviour
{
    public override string GetLiquidID() => SpazSerum.ID;

    public class SpazSerum : Liquid
    {
        public const string ID = "Spaz SERUM-OD";

        public SpazSerum()
        {
            Color = new UnityEngine.Color(0f, 1f, 1f, 1);
        }

        public override void OnEnterLimb(LimbBehaviour limb)
        {
            limb.Wince(22500000f);
        }

        public override void OnUpdate(BloodContainer container) { }
        public override void OnEnterContainer(BloodContainer container) { }
        public override void OnExitContainer(BloodContainer container) { }

    }
}
public class LSSyringe : SyringeBehaviour
{
    public override string GetLiquidID() => LSSerum.ID;

    public class LSSerum : Liquid
    {
        public const string ID = "Life Steal SERUM-OD";

        public LSSerum()
        {
            Color = new UnityEngine.Color(1f, 0.56f, 0f, 1);
        }

        public override void OnEnterLimb(LimbBehaviour limb)
        {
            limb.Person.Consciousness = 0f;
            limb.Person.ShockLevel = 0;
            limb.Person.PainLevel = 0;
            limb.Person.OxygenLevel = 0;
            limb.Person.AdrenalineLevel = 0;
        }

        public override void OnUpdate(BloodContainer container) { }
        public override void OnEnterContainer(BloodContainer container) { }
        public override void OnExitContainer(BloodContainer container) { }

    }
}

public class KabooieSyringe : SyringeBehaviour
{
    public override string GetLiquidID() => KabooieSerum.ID;

    public class KabooieSerum : Liquid
    {
        public const string ID = "KABOOIE SERUM-OD";

        public KabooieSerum()
        {
            Color = new UnityEngine.Color(0.99f, 1f, 0f, 1);
        }

        public override void OnEnterLimb(LimbBehaviour limb)
        {
            ExplosionCreator.CreateFragmentationExplosion(35U, limb.transform.position, 1f,1f,true);
        }

        public override void OnUpdate(BloodContainer container) { }
        public override void OnEnterContainer(BloodContainer container) { }
        public override void OnExitContainer(BloodContainer container) { }

    }
}

public class RNSyringe : SyringeBehaviour
{
    public override string GetLiquidID() => RNSerum.ID;

    public class RNSerum : Liquid
    {
        public const string ID = "RISOTTO NERO SERUM-OD";

        public RNSerum()
        {
            Color = new UnityEngine.Color(0.64f, 0f, 1f, 1);
        }

        public override void OnEnterLimb(LimbBehaviour limb)
        {
            new WaitForSeconds(UnityEngine.Random.Range(5f, 10f));
            limb.BreakingThreshold = 0f;
            Vector2 vector = new Vector2();
            vector.x = limb.PhysicalBehaviour.rigidbody.transform.position.x;
            vector.y = limb.PhysicalBehaviour.rigidbody.transform.position.y;
            if (UnityEngine.Random.Range(1, 5) == 1)
            {
                ModAPI.CreateParticleEffect("BloodExplosion", vector);
            }
        }

        public override void OnUpdate(BloodContainer container) { }
        public override void OnEnterContainer(BloodContainer container) { }
        public override void OnExitContainer(BloodContainer container) { }

    }
}

public class FPSyringe : SyringeBehaviour
{
    public override string GetLiquidID() => FPSerum.ID;

    public class FPSerum : Liquid
    {
        public const string ID = "Flesh Poison SERUM-OD";

        public FPSerum()
        {
            Color = new UnityEngine.Color(0.45f, 0.54f, 0f, 1);
        }

        public override void OnEnterLimb(LimbBehaviour limb)
        {
            while (limb.SkinMaterialHandler.AcidProgress < 0.60f)
            {
                limb.SkinMaterialHandler.AcidProgress += Time.deltaTime * 0.5f;
                new WaitForSeconds(0.03f);
            }
            while (limb.SkinMaterialHandler.AcidProgress < 0.75f)
            {
                Vector2 vector = new Vector2();
                vector.x = limb.PhysicalBehaviour.rigidbody.transform.position.x;
                vector.y = limb.PhysicalBehaviour.rigidbody.transform.position.y;
                if (UnityEngine.Random.Range(1, 450) == 1)
                {
                    ModAPI.CreateParticleEffect("BloodExplosion", vector);
                }
                limb.SkinMaterialHandler.AcidProgress += Time.deltaTime * 0.05f;
                new WaitForSeconds(0.03f);
            }
            limb.Health *= 0.6f;
            limb.BreakingThreshold *= 0.8f;
        }


        public override void OnUpdate(BloodContainer container) { }
        public override void OnEnterContainer(BloodContainer container) { }
        public override void OnExitContainer(BloodContainer container) { }

    }
}

    public class NESyringe : SyringeBehaviour
    {
        public override string GetLiquidID() => NESerum.ID;

        public class NESerum : Liquid
        {
            public const string ID = "NECROSIS SERUM-OD";

            public NESerum()
            {
                Color = new UnityEngine.Color(1f, 0f, 0.96f, 1);
            }

            public override void OnEnterLimb(LimbBehaviour limb)
            {
                if (limb.SkinMaterialHandler.AcidProgress < 0.2f)
                {
                    limb.SkinMaterialHandler.AcidProgress = 0.2f;
                }
                while (limb.SkinMaterialHandler.AcidProgress < 0.5f)
                {
                    limb.SkinMaterialHandler.RottenProgress += Time.deltaTime * 0.02f;
                    limb.SkinMaterialHandler.AcidProgress += Time.deltaTime * 0.015f;
                    new WaitForEndOfFrame();
                }
                limb.Health = 0f;
                limb.CirculationBehaviour.IsPump = false;
                while (limb.SkinMaterialHandler.RottenProgress < 1f)
                {
                    limb.SkinMaterialHandler.RottenProgress += Time.deltaTime * 0.02f;
                    limb.SkinMaterialHandler.AcidProgress += Time.deltaTime * 0.009f;
                    new WaitForEndOfFrame();
                }
            }


            public override void OnUpdate(BloodContainer container) { }
            public override void OnEnterContainer(BloodContainer container) { }
            public override void OnExitContainer(BloodContainer container) { }

        } }

}