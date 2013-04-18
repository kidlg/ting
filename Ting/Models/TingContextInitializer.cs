using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Ting.Models
{
    /// <summary>
    /// 测试时使用的初始化部分数据
    /// create by lg 2013-1-15
    /// </summary>
    public class TingContextInitializer : DropCreateDatabaseIfModelChanges<TingContext>
    {
        protected override void Seed(TingContext context)
        {
            #region 初始化信息
            //初始化用户数据
            var users = new List<User>()
            {
                new User{ Name="原野", RegTime= DateTime.Now},
                new User {Name= "屁屁球",RegTime= DateTime.Now},
                new User {Name = "栗子小单",RegTime = DateTime.Now},
                new User {Name = "单田芳",RegTime = DateTime.Now},
                new User {Name = "连丽如",RegTime = DateTime.Now},
                new User {Name="牟云",RegTime = DateTime.Now}
            };

            users.ForEach(p => context.Users.Add(p));
            context.SaveChanges();

            //初始化分类信息
            var categories = new List<Category>()
            {
                new Category(){ Name="都市言情", Hot =0, Sort=0, ParentCateId=0, Sum =0, CreateTime = DateTime.Now},
                new Category(){ Name="恐怖悬疑", Hot =0, Sort=0, ParentCateId=0, Sum =0, CreateTime = DateTime.Now},
                new Category(){ Name="穿越搞笑", Hot =0, Sort=0, ParentCateId=0, Sum =0, CreateTime = DateTime.Now},
                new Category(){ Name="单田芳", Hot =0, Sort=0, ParentCateId=0, Sum =0, CreateTime = DateTime.Now},
                new Category(){ Name="连丽如", Hot =0, Sort=0, ParentCateId=0, Sum =0, CreateTime = DateTime.Now},
                new Category(){ Name="分类6", Hot =0, Sort=0, ParentCateId=0, Sum =0, CreateTime = DateTime.Now},
            };
            categories.ForEach(p => context.Categories.Add(p));
            context.SaveChanges();

            //初始化作品信息
            var works = new List<Work>()
            {
                new Work(){ Breif="主要讲述一个坏蛋的成长有人就有恩怨，有恩怨，就有江湖。人就是江湖，叫我怎么退出。男人就应该响当当的活着。年少时的江湖梦...... 这是坏蛋的领域，属于坏蛋的时代。男人与男人之间的诺言，刀与刀之间火焰，让我们一起去领略真男儿洒血.扶剑.高歌的豪情，去欣赏逆天.叛地.逐鹿的气概......",
                    CateId =1, AnnoucerName="原野", AnnouncerId=1, Author="六道", Hot=0, Name="坏蛋是怎样炼成的一", SectionSum=1, Sort=0, CreateTime=DateTime.Now},
                new Work(){ Breif="主要讲述一个坏蛋的成长有人就有恩怨，有恩怨，就有江湖。人就是江湖，叫我怎么退出。男人就应该响当当的活着。年少时的江湖梦...... 这是坏蛋的领域，属于坏蛋的时代。男人与男人之间的诺言，刀与刀之间火焰，让我们一起去领略真男儿洒血.扶剑.高歌的豪情，去欣赏逆天.叛地.逐鹿的气概......",
                    CateId =1, AnnoucerName="原野",AnnouncerId=1, Author="六道", Hot=1, Name="坏蛋是怎样炼成的二", SectionSum=2, Sort=1, CreateTime=DateTime.Now},
                new Work(){ Breif="生活，它有时让你觉得渺茫，有时让你又很痛苦，有时却也会给你带来快乐，实在，正如一位诗人说的那样，生活就是一张网，而爱情就像似在被网在生活中的一种特别的东西，总之，酸的甜的苦的痛的伤的笑的悲的喜的哀的怒的都被牢牢的网在了里面。这不，为了生存，为了逃避爱情，为了不使自已继续的被网在爱情的天堂里面，我不得不又在这座陌生的乡村里往重新开始选择，不得不为了给自已的那曾经沧伤的情感重新安一个新的家园。说实话，假如不是由于欣，我是说什么也不会离开那座生我养我的乡村，说什么我也不会躲逃到这样一个让人无奈而又陌生的不再陌生的乡村里往的。我和欣是在一个多月前分的手，我们辨别的那天，我记的十分的清楚，天空中还飘着细……",
                    CateId =1, AnnoucerName="佚名", Author="佚名", Hot=1, Name="我和妓女同居的生活", SectionSum=3, Sort=2, CreateTime=DateTime.Now},
                new Work(){ Breif="这个世界上的空间有很多种，有阳间与阴间，人鬼互不侵犯。但在人类的阳间里又有许多飘荡鬼，他们生前的怨气还停留在阳间，一直不肯散去。 　　  一个通晓鬼怪的年轻人，叶翼，天生具有阴阳眼，受高人指点，本领高强。他的身世却是个迷，不知道自己来自哪儿，家是哪里。没有人能占卜出他的前世今生。在他遇见一个神秘高人时，却告诉他在今当中会遇见三个人来决定自己的命运。 ",
                    CateId =2, AnnoucerName="屁屁球",AnnouncerId=2, Author="崔走召", Hot=1,  Name="我当阴阳师的那几年", SectionSum=2, Sort=0, CreateTime=DateTime.Now},
                new Work(){ Breif="暂无简介", 
                    CateId =3, AnnoucerName="栗子小单",AnnouncerId=3, Author="玉朵朵", Hot=1, Name="步步惊心", SectionSum=2, Sort=0, CreateTime=DateTime.Now},
                new Work(){ Breif="一个叫颂莲的新女性以纳妾的方式走进一个旧家庭，她几乎是自觉地成为旧式婚姻的牺牲品。布满女人味的颂莲谙习女人之间的争风吃醋和勾心斗角，甚至以床上的机敏搏取老爷的欢心。然而，她清纯的气质和直率的品性终究拯救不了一个作妾的命运。", 
                    CateId =3, AnnoucerName="牟云",AnnouncerId=6,Author="苏童", Hot=1, Name="妻妾成群", SectionSum=2, Sort=1, CreateTime=DateTime.Now},
                new Work(){ Breif="为什么要穿越？！我为什么要穿？！” “不穿会着凉……”假如你也曾以为这只是一部穿越小说…… 宝马算什么？美男靠边站！作为一个受过高等教育的现在知识女性，怎能忍受没有电脑、没有巧克力、没有冲水马桶的落后生活？无论如何也得给我穿回来！顾清乔与时俱进的乌龙人生传奇，恶搞……", 
                    CateId =3, AnnoucerName="佚名",Author="影照", Hot=1, Name="午门囧事I帝陵篇", SectionSum=2, Sort=2, CreateTime=DateTime.Now},
                new Work(){ Breif="宋朝仁宗皇帝执政期间，以徐良、蒋平、白芸瑞为首的三侠、七杰、小五义等众开封府校尉，在八王赵德芳、包拯、颜查散等清官的支持下，为保国泰民安而不顾个人安危，抗强暴、战邪恶、捣匪巢、灭贼寇，在众多武林豪杰的大力协助下，先后与勾结外匪、图谋反叛的阎王寨众贼、三教堂恶徒、三仙岛凶僧魔头展开了生死搏斗，其间还不断遭受奸臣陷害，屡屡背腹受敌，身处险境。但众英雄义士不畏艰险、舍生忘死、爱憎分明、有勇有谋，利用高超的斗争艺术与惊人的武艺，最终消灭顽敌，为国为民立下不朽功勋。", 
                    CateId =4, AnnoucerName="单田芳",AnnouncerId=4,Author="鸿达以太", Hot=1, Name="白眉大侠", SectionSum=4, Sort=0, CreateTime=DateTime.Now},
                new Work(){ Breif="汉末三国一统回晋，西晋之后东晋分为十六国，到了南北朝时期，隋文帝杨坚扫灭南陈，终于在公元581年统一了中国。\n    杨坚的二儿子杨广为夺皇位，弑父夺权、欺娘戏妹、鸩兄图嫂，成为隋朝第二个天子隋炀帝。\n    隋朝在短短的三十七年里，皇族内部和朝臣中倾轧十分厉害。天下纷争，十八家反王割据城池。南陈的后代秦琼、程咬金、罗成与绿林豪杰单雄信等人结为四十六友，两次反山东，占据了瓦岗山，打退了隋朝杨林的几次围剿。他们在瓦岗与唐国公李渊父子，召集天下群雄反隋兴唐，终于在四平山一战，确定胜局，后来兵取长安灭了隋朝，定国号大唐。\n         李世民招抚瓦岗寨众英雄，扫灭各路反王，一统大唐山河。", 
                    CateId =5,AnnoucerName="连丽如",AnnouncerId=5,Author="佚名", Hot=1, Name="大隋唐", SectionSum=1, Sort=0, CreateTime=DateTime.Now}
            };
            works.ForEach(p => context.Works.Add(p));
            context.SaveChanges();

            //初始化剧集信息
            var sections = new List<Section>()
            {
                new Section(){ Name="坏蛋是怎样炼成的一_1", Content="/Sounds/1/8/91/1.mp3", SectionsTime="0", Sort =0, WorkId=1, CreateTime=DateTime.Now},
                new Section(){ Name="坏蛋是怎样炼成的二_1", Content="/Sounds/1/8/92/1.mp3", SectionsTime="0", Sort =0, WorkId=2, CreateTime=DateTime.Now},
                new Section(){ Name="坏蛋是怎样炼成的二_2", Content="/Sounds/1/8/92/2.mp3", SectionsTime="0", Sort =1, WorkId=2, CreateTime=DateTime.Now},
                new Section(){ Name="我和妓女同居的生活_1", Content="/Sounds/1/8/97/1.mp3", SectionsTime="0", Sort =0, WorkId=3, CreateTime=DateTime.Now},
                new Section(){ Name="我和妓女同居的生活_2", Content="/Sounds/1/8/97/2.mp3", SectionsTime="0", Sort =1, WorkId=3, CreateTime=DateTime.Now},
                new Section(){ Name="我和妓女同居的生活_3", Content="/Sounds/1/8/97/3.mp3", SectionsTime="0", Sort =2, WorkId=3, CreateTime=DateTime.Now},
                new Section(){ Name="我当阴阳师的那几年1", Content="/Sounds/1/9/343/1.mp3", SectionsTime="0", Sort =0, WorkId=4, CreateTime=DateTime.Now},
                new Section(){ Name="步步惊心_1",          Content="/Sounds/1/10/79/1.mp3", SectionsTime="0", Sort =0, WorkId=5, CreateTime=DateTime.Now},
                new Section(){ Name="步步惊心_2",          Content="/Sounds/1/10/79/2.mp3", SectionsTime="0", Sort =1, WorkId=5, CreateTime=DateTime.Now},
                new Section(){ Name="妻妾成群_1",          Content="/Sounds/1/10/80/1.mp3", SectionsTime="0", Sort =0, WorkId=6, CreateTime=DateTime.Now},
                new Section(){ Name="妻妾成群_2",          Content="/Sounds/1/10/80/2.mp3", SectionsTime="0", Sort =1, WorkId=6, CreateTime=DateTime.Now},
                new Section(){ Name="午门囧事I帝陵篇_1", Content="/Sounds/1/10/81/1.mp3", SectionsTime="0", Sort =0, WorkId=7, CreateTime=DateTime.Now},
                new Section(){ Name="午门囧事I帝陵篇_2", Content="/Sounds/1/10/81/2.mp3", SectionsTime="0", Sort =1, WorkId=7, CreateTime=DateTime.Now},
                new Section(){ Name="白眉大侠_1", Content="/Sounds/3/19/425/1.mp3", SectionsTime="0", Sort =0, WorkId=8, CreateTime=DateTime.Now},
                new Section(){ Name="白眉大侠_2", Content="/Sounds/3/19/425/2.mp3", SectionsTime="0", Sort =1, WorkId=8, CreateTime=DateTime.Now},
                new Section(){ Name="白眉大侠_3", Content="/Sounds/3/19/425/3.mp3", SectionsTime="0", Sort =2, WorkId=8, CreateTime=DateTime.Now},
                new Section(){ Name="白眉大侠_4", Content="/Sounds/3/19/425/4.mp3", SectionsTime="0", Sort =3, WorkId=8, CreateTime=DateTime.Now},
                new Section(){ Name="连丽如_大隋唐_1", Content="/Sounds/3/20/990/1.mp3", SectionsTime="0", Sort =0, WorkId=9, CreateTime=DateTime.Now},
            };

            sections.ForEach(p => context.Sections.Add(p));
            context.SaveChanges();

            //初始化评论
            var comments = new List<Comment>() {
                new Comment(){ NickName="lg", Content="不错不错不错不错", Level=1, WorkId=1,CreateTime= DateTime.Now},
                new Comment(){ NickName="geyao", Content="不错不asfadsf错不错不错", Level=1, WorkId=1,CreateTime= DateTime.Now},
                new Comment(){ NickName="safadsf", Content="不错不错adsfds不错不错", Level=1, WorkId=2,CreateTime= DateTime.Now},
                new Comment(){ NickName="niming", Content="不错不错不；拉升阶段法搜房基地覅asdfsa哦啊多少分开了大错不错", Level=1, WorkId=2,CreateTime= DateTime.Now},
                new Comment(){ NickName="niming", Content="不错不错不；拉升阶段法搜房基地覅哦啊多少分开了大错不错", Level=1, WorkId=2,CreateTime= DateTime.Now},
                new Comment(){ NickName="niming", Content="不错不错不；拉升阶sadasdaf段法搜房基地覅哦啊多cvczx少分开了大错不错", Level=1, WorkId=2,CreateTime= DateTime.Now},
                new Comment(){ NickName="ss", Content="不错不错不错就覅哦女空寂哦不错", Level=1, WorkId=3,CreateTime= DateTime.Now}
            };
            comments.ForEach(p => context.Comments.Add(p));
            context.SaveChanges();
            #endregion

        }
    }
}