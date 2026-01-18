using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static NLEditor.C;

namespace NLEditor
{
    public static class C // for Constants
    {
        public static string Version
        {
            get
            {
                var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

                if (version.Build > 0)
                {
                    return version.Major.ToString() + "." + version.Minor.ToString() + "." + version.Build.ToString();
                }
                else
                {
                    return version.Major.ToString() + "." + version.Minor.ToString();
                }
            }
        }

        public static string AppPath => System.Windows.Forms.Application.StartupPath + DirSep;
        public static string AppPathAutosave => AppPath + "autosave" + DirSep;
        public static string AppPathPieces => AppPath + "styles" + DirSep;
        public static string AppPathRulers => AppPath + "rulers" + DirSep;
        public static string AppPathMusic => AppPath + "music" + DirSep;
        public static string AppPathLevels => AppPath + "levels" + DirSep;
        public static string AppPathTempLevel => AppPath + "TempTestLevel.nxlv";
        public static string AppPathThemeInfo(string styleName) => AppPathPieces + styleName + C.DirSep + "theme.nxtm";
        public static string AppPathSettings => AppPath + "settings" + DirSep + "NLEditorSettings.ini";
        public static string AppPathHotkeys => AppPath + "settings" + DirSep + "NLEditorHotkeys.ini";
        public static string AppPathCustomSkillsets => AppPath + "settings" + DirSep + "NLEditorCustomSkillsets.ini";
        public static string AppPathTranslationTables => AppPath + "settings" + DirSep + "NLEditorINITranslationTables.ini";
        public static string AppPathPlayerSettings => AppPath + "settings" + DirSep + "settings.ini";
        public static string AppPathPlayerSettingsOld => AppPath + "NeoLemmix147Settings.ini";
        public static string AppPathNeoLemmix => AppPath + "NeoLemmix.exe";
        public static string AppPathNeoLemmixCE => AppPath + "NeoLemmixCE.exe";

        public static char DirSep => System.IO.Path.DirectorySeparatorChar;
        public static string NewLine => Environment.NewLine;

        public static Size PicPieceSize => new Size(84, 84);

        public static ScreenSize ScreenSize;

        public enum SelectPieceType
        {
            Terrain, Steel, Objects, Rulers, Backgrounds
        }

        public enum DisplayType
        {
            Terrain, Objects, Triggers, Rulers, ScreenStart,
            Background, ClearPhysics, Deprecated
        }

        public enum CustDrawMode
        {
            Default, DefaultOWW, Erase, OnlyAtMask, OnlyAtOWW,
            NoOverwrite, NoOverwriteOWW,
            ClearPhysics, ClearPhysicsOWW, ClearPhysicsSteel,
            ClearPhysicsNoOverwrite, ClearPhysicsNoOverwriteOWW, ClearPhysicsSteelNoOverwrite,
            HighlightGrouped,
            Custom
        }

        public enum DIR { N, E, S, W }

        /// <summary>
        /// Warning: The values of the object types here do NOT correspond to the numbers used in NeoLemmix! 
        /// </summary>
        public enum OBJ
        {
            TERRAIN = -1, STEEL = -2, RULER = -3,
            LEMMING = 0, HATCH = 1, EXIT = 2, EXIT_LOCKED = 3,
            TRAP = 4, TRAPONCE = 5, FIRE = 6, WATER = 7,
            ONE_WAY_WALL = 8, FORCE_FIELD = 9,
            PICKUP = 10, BUTTON = 11,
            TELEPORTER = 12, RECEIVER = 13,
            UPDRAFT = 14, SPLAT = 15, SPLITTER = 16,
            DECORATION = 17, PAINT = 18,
            PORTAL = 19,
            NEUTRALIZER = 20, DENEUTRALIZER = 21,
            PERMASKILL_ADD = 22, PERMASKILL_REMOVE = 23,
            SKILL_ASSIGNER = 24,
            NONE = 100, NULL
        }

        public static OBJ[] HideTriggerObjects = new OBJ[] { OBJ.TERRAIN, OBJ.STEEL, OBJ.RULER, OBJ.NONE, OBJ.DECORATION, OBJ.NULL, OBJ.PAINT };
        public static OBJ[] TriggerPointObjects = new OBJ[] { OBJ.HATCH, OBJ.RECEIVER };

        public enum StyleColor
        {
            BACKGROUND, ONE_WAY_WALL, MASK, PICKUP_BORDER, PICKUP_INSIDE
        }
        public static NLColor ToNLColor(this StyleColor styleColor)
        {
            switch (styleColor)
            {
                case StyleColor.BACKGROUND:
                    return NLColor.BackDefault;
                case StyleColor.ONE_WAY_WALL:
                    return NLColor.OWWDefault;
                default:
                    return NLColor.BackDefault;
            }
        }

        public static readonly Dictionary<OBJ, string> ObjectDescriptions = new Dictionary<OBJ, string>
        {
          {OBJ.TERRAIN, "Terrain"}, {OBJ.STEEL, "Steel"}, {OBJ.RULER, "Ruler"}, {OBJ.NONE, "No Effect"},
          {OBJ.EXIT, "Exit"}, {OBJ.FORCE_FIELD, "Force-Field"}, {OBJ.ONE_WAY_WALL, "One-Way"}, {OBJ.PAINT, "Paint"},
          {OBJ.TRAP, "Trap"}, {OBJ.WATER, "Water"}, {OBJ.FIRE, "Fire"},
          {OBJ.TELEPORTER, "Teleporter"}, {OBJ.RECEIVER, "Receiver"}, {OBJ.LEMMING, "Lemming"},
          {OBJ.PICKUP, "Pickup Skill"}, {OBJ.EXIT_LOCKED, "Locked Exit"}, {OBJ.BUTTON, "Button"},
          {OBJ.UPDRAFT, "Updraft"}, {OBJ.SPLITTER, "Splitter"}, {OBJ.HATCH, "Hatch"},
          {OBJ.SPLAT, "Splat Pad"}, {OBJ.DECORATION, "Decoration"}, {OBJ.TRAPONCE, "Single Trap"},
          {OBJ.PORTAL, "Portal" }, {OBJ.NEUTRALIZER, "Neutralizer" }, {OBJ.PERMASKILL_ADD, "PermaSkill Assigner" },
          {OBJ.DENEUTRALIZER, "Deneutralizer" }, {OBJ.PERMASKILL_REMOVE, "PermaSkill Remover" }, {OBJ.SKILL_ASSIGNER, "Skill Assigner"}
        };

        public enum DragActions
        {
            Null, SelectArea, MaybeDragPieces,
            DragPieces, HorizontalDrag, VerticalDrag,
            DragNewPiece, MoveEditorPos, MoveStartPos
        }

        public enum Resize { None, Vert, Horiz, Both }

        public static readonly byte ALPHA_OWW = 255;
        public static readonly byte ALPHA_NOOWW = 254;

        public enum Layer { Background, ObjBack, Terrain, ObjTop, Triggers, Rulers }
        public static readonly List<Layer> LayerList = new List<Layer>()
    {
      Layer.Background, Layer.ObjBack, Layer.Terrain, Layer.ObjTop, Layer.Triggers, Layer.Rulers
    };

        // The integer values here are only used to pick the correct frame of pickupanim.png
        public enum Skill
        {
            // Non-pickup-skills need to be <0 as they aren't used
            Neutral = -3, Zombie = -2,
            
            // Use frame 0 for Skill.None
            None = 0,

            // All pickup skills are 2 frames apart
            Walker = 1, Jumper = 3, Shimmier = 5,
            Slider = 7, Climber = 9, Swimmer = 11,
            Floater = 13, Glider = 15, Disarmer = 17,
            Bomber = 19, Stoner = 21,
            Blocker = 23,
            Platformer = 25, Builder = 27, Stacker = 29,
            Laserer = 31, Basher = 33, Fencer = 35,
            Miner = 37, Digger = 39,
            Cloner = 41
        };
        public static Array SkillArray => Enum.GetValues(typeof(C.Skill));

        public static readonly HashSet<Skill> PermaSkills = new HashSet<Skill>
        {
            Skill.Slider,
            Skill.Climber,
            Skill.Swimmer,
            Skill.Floater,
            Skill.Glider,
            Skill.Disarmer
        };

        public static readonly int ZOOM_MIN = -2;
        public static readonly int ZOOM_MAX = 10;

        public static readonly int LEM_OFFSET_X = 2;
        public static readonly int LEM_OFFSET_Y = 9;

        // Other colors are specified directly in BmpModify to speed up rendering.
        public enum NLColor
        {
            Text, OWWDefault, BackDefault, ScreenStart,
            SelRectGadget, SelRectTerrain, SelRectSteel, SelRectRulers,
            TriggerPink, TriggerYellow, TriggerGreen, TriggerBlue, TriggerPurple
        }
        public static readonly Dictionary<NLColor, Color> TriggerColors = new Dictionary<NLColor, Color>()
        {
          { NLColor.TriggerPink, Utility.HexToColor("55EE88EE") }, // Pink with reduced alpha
          { NLColor.TriggerYellow, Utility.HexToColor("44FFDD00") }, // Banana with reduced alpha
          { NLColor.TriggerGreen, Utility.HexToColor("4411FFAA") }, // Mint with reduced alpha
          { NLColor.TriggerBlue, Utility.HexToColor("4400FFFF") }, // Cyan with reduced alpha
          { NLColor.TriggerPurple, Utility.HexToColor("44AA00FF") }, // Indigo with reduced alpha
        };
        public static readonly Dictionary<NLColor, Color> NLColors = new Dictionary<NLColor, Color>()
        {
          { NLColor.Text, Utility.HexToColor("FEF5F5F5") }, // Color.WhiteSmoke with slightly reduced alpha
          { NLColor.OWWDefault, Color.Linen },
          { NLColor.BackDefault, Color.Black },
          { NLColor.ScreenStart, Color.AliceBlue },
          { NLColor.SelRectGadget, Color.Chartreuse },
          { NLColor.SelRectTerrain, Color.Gold },
          { NLColor.SelRectSteel, Color.LightSteelBlue },
          { NLColor.SelRectRulers, Color.Violet }
        };

        public enum TalismanType { Bronze, Silver, Gold }
        public enum TalismanReq
        {
            SaveReq, TimeLimit,
            SkillTotal, SkillTypes, SkillEachLimit,
            SkillWalker, SkillJumper, SkillShimmier,
            SkillSlider, SkillClimber, SkillSwimmer, SkillFloater, SkillGlider,
            SkillDisarmer, SkillBomber, SkillStoner,
            SkillBlocker,
            SkillPlatformer, SkillBuilder, SkillStacker,
            SkillLaserer, SkillBasher, SkillFencer, SkillMiner, SkillDigger,
            SkillCloner,
            UseOnlySkill
        }
        public static Array TalismanReqArray => Enum.GetValues(typeof(C.TalismanReq));

        public static readonly List<string> TalismanSkills = new List<string>()
        {
            "Walker", "Jumper", "Shimmier",
            "Slider", "Climber", "Swimmer", "Floater", "Glider", 
            "Disarmer", "Bomber", "Stoner",
            "Blocker",
            "Platformer", "Builder", "Stacker",
            "Laserer", "Basher", "Fencer", "Miner", "Digger",
            "Cloner"
        };

        public static readonly Dictionary<TalismanReq, string> TalismanReqText = new Dictionary<TalismanReq, string>()
        {
            { TalismanReq.SaveReq, "Save Requirement" },
            { TalismanReq.TimeLimit, "Time Limit" },
            { TalismanReq.SkillTotal, "Limit Total Skills" },
            { TalismanReq.SkillTypes, "Limit Skill Types" },
            { TalismanReq.SkillWalker, "Limit Walkers" },
            { TalismanReq.SkillJumper, "Limit Jumpers" },
            { TalismanReq.SkillShimmier, "Limit Shimmiers" },
            { TalismanReq.SkillSlider, "Limit Sliders" },
            { TalismanReq.SkillClimber, "Limit Climbers" },
            { TalismanReq.SkillSwimmer, "Limit Swimmers" },
            { TalismanReq.SkillFloater, "Limit Floaters" },
            { TalismanReq.SkillGlider, "Limit Gliders" },
            { TalismanReq.SkillDisarmer, "Limit Disarmers" },
            { TalismanReq.SkillBomber, "Limit Bombers" },
            { TalismanReq.SkillStoner, "Limit Stoners" },
            { TalismanReq.SkillBlocker, "Limit Blockers" },
            { TalismanReq.SkillPlatformer, "Limit Platformers" },
            { TalismanReq.SkillBuilder, "Limit Builders" },
            { TalismanReq.SkillStacker, "Limit Stackers" },
            { TalismanReq.SkillLaserer, "Limit Laserers" },
            { TalismanReq.SkillBasher, "Limit Bashers" },
            { TalismanReq.SkillFencer, "Limit Fencers" },
            { TalismanReq.SkillMiner, "Limit Miners" },
            { TalismanReq.SkillDigger, "Limit Diggers" },
            { TalismanReq.SkillCloner, "Limit Cloners" },
            { TalismanReq.SkillEachLimit, "Limit All Skills" },
            { TalismanReq.UseOnlySkill, "Using only the Skill" }
        };

        public static readonly Dictionary<TalismanReq, string> TalismanKeys = new Dictionary<TalismanReq, string>()
        {
          { TalismanReq.SaveReq, "SAVE_REQUIREMENT" }, { TalismanReq.TimeLimit, "TIME_LIMIT" },
          { TalismanReq.SkillTotal, "SKILL_LIMIT" }, { TalismanReq.SkillTypes, "SKILL_TYPE_LIMIT" },
          { TalismanReq.SkillWalker, "WALKER_LIMIT" },
          { TalismanReq.SkillJumper, "JUMPER_LIMIT" }, { TalismanReq.SkillShimmier, "SHIMMIER_LIMIT" },
          { TalismanReq.SkillSlider, "SLIDER_LIMIT" }, { TalismanReq.SkillClimber, "CLIMBER_LIMIT"},
          { TalismanReq.SkillSwimmer, "SWIMMER_LIMIT"}, { TalismanReq.SkillFloater, "FLOATER_LIMIT" },
          { TalismanReq.SkillGlider, "GLIDER_LIMIT" }, { TalismanReq.SkillDisarmer, "DISARMER_LIMIT" },
          { TalismanReq.SkillBomber, "BOMBER_LIMIT" },
          { TalismanReq.SkillStoner, "STONER_LIMIT"},
          { TalismanReq.SkillBlocker, "BLOCKER_LIMIT"},
          { TalismanReq.SkillPlatformer, "PLATFORMER_LIMIT" },
          { TalismanReq.SkillBuilder, "BUILDER_LIMIT" }, { TalismanReq.SkillStacker, "STACKER_LIMIT" },
          { TalismanReq.SkillLaserer, "LASERER_LIMIT" },
          { TalismanReq.SkillBasher, "BASHER_LIMIT" }, { TalismanReq.SkillMiner, "MINER_LIMIT" },
          { TalismanReq.SkillDigger, "DIGGER_LIMIT" }, { TalismanReq.SkillFencer, "FENCER_LIMIT" },
          { TalismanReq.SkillCloner, "CLONER_LIMIT" }, { TalismanReq.SkillEachLimit, "SKILL_EACH_LIMIT" },
          { TalismanReq.UseOnlySkill, "USE_ONLY_SKILL" }
        };

        public static readonly string[] MusicExtensions = new List<string>()
        {
          ".ogg", ".it", ".mp3", ".mo3", ".wav", ".aiff", ".aif",
          ".mod", ".xm", ".s3m", ".mtm", ".umx"
        }.ToArray();

        public static readonly List<string> MusicNames = new List<string>()
        {
          "orig_01", "orig_02", "orig_03", "orig_04", "orig_05", "orig_06", "orig_07", "orig_08", "orig_09", "orig_10",
          "orig_11", "orig_12", "orig_13", "orig_14", "orig_15", "orig_16", "orig_17",
          "awesome", "beasti", "beastii", "menace",
          "ohno_01", "ohno_02", "ohno_03", "ohno_04", "ohno_05", "ohno_06",
          "WillLem_Xmas_Music/WL_Ding_Dong", "WillLem_Xmas_Music/WL_Hark_Angels",
          "WillLem_Xmas_Music/WL_Jingle_Bells", "WillLem_Xmas_Music/WL_O_Holy_Night",
          "WillLem_Xmas_Music/WL_Rockin_Around", "WillLem_Xmas_Music/WL_Rudolph",
          "WillLem_Xmas_Music/WL_Twelve_Days", "WillLem_Xmas_Music/WL_Winter_Wonderland",
          "xmas_01", "xmas_02", "xmas_03"
        };

        public static readonly Dictionary<int, string> FileConverterErrorMsg = new Dictionary<int, string>()
        {
          { 2, "Warning: Could not convert some object properties to the nxlv. format due to missing .nxmo files." },
          { 90, "Error: Level converter got passed invalid file paths." },
          { 92, "Error: Level converter could not find the translation table .nxtt for the graphic style used in the level." },
          { 99, "Error: Level converter encountered an unknown error." }
        };
    }
}
