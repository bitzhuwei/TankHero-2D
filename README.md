# TankHero-2D
a 2d tank game written in Unity
<p>自制Unity小游戏TankHero-2D(1)制作主角坦克</p>
<p>我在做这样一个坦克游戏，是仿照（<a href="http://game.kid.qq.com/a/20140221/028931.htm" target="_blank">http://game.kid.qq.com/a/20140221/028931.htm</a>）这个游戏制作的。仅为学习Unity之用。图片大部分是自己画的，少数是从网上搜来的。您可以到我的github页面（<a href="https://github.com/bitzhuwei/TankHero-2D" target="_blank">https://github.com/bitzhuwei/TankHero-2D</a>）上得到工程源码。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290019571755050.png"><img style="display: inline; border: 0px;" title="clip_image002" src="http://images.cnitblog.com/blog/383191/201501/290020023621968.png" alt="clip_image002" width="560" height="299" border="0" /></a></p>
<p>本篇主要记录制作主角坦克（TankHero）的一些重点。</p>
<h1>2D游戏布局</h1>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290020042229269.jpg"><img style="display: inline; border: 0px;" title="clip_image004" src="http://images.cnitblog.com/blog/383191/201501/290020068167728.jpg" alt="clip_image004" width="558" height="249" border="0" /></a></p>
<p>如上图所示，红色矩形围起来的是<span style="color: #ff0000;">主角坦克</span>，白色的一圈是<span style="color: #ff0000;">围墙</span>，坦克和围墙在同一平面上。<span style="color: #ff0000;">地面背景</span>放到离摄像机最远的后方。这样，在2D摄像机下看起来是这样的：</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290020086599259.jpg"><img style="display: inline; border: 0px;" title="clip_image006" src="http://images.cnitblog.com/blog/383191/201501/290020107222389.jpg" alt="clip_image006" width="558" height="265" border="0" /></a></p>
<p>坦克本身由<span style="color: #ff0000;">底座</span>（Base）和<span style="color: #ff0000;">炮塔</span>（Head）两部分组成。当然，在2D世界，其实就是两个扁平的贴图。在2D摄像机下是这样的：</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290020137537148.png"><img style="display: inline; border: 0px;" title="clip_image007" src="http://images.cnitblog.com/blog/383191/201501/290020181281652.png" alt="clip_image007" width="471" height="273" border="0" /></a></p>
<p>（PS：上图中的绿色矩形框是Box Collider 2D，忽略即可）</p>
<p>为了保证炮塔始终显示在底座上方，我们要让炮塔稍微靠近一点摄像机。如下图所示，炮塔和底座两张贴图是<span style="color: #ff0000;">分隔开</span>的。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290020194255381.png"><img style="display: inline; border: 0px;" title="clip_image008" src="http://images.cnitblog.com/blog/383191/201501/290020205342054.png" alt="clip_image008" width="420" height="290" border="0" /></a></p>
<h1>坦克的运动</h1>
<p>坦克的运动包括：上下左右平移；底座旋转；炮塔旋转。其中平移时会同样地移动底座和炮塔，所以用最上层的TankHero负责。底座和炮塔的旋转我们要求两者互不干涉，所以TankHead和TankBase放在同一层，并且分别负责各自的旋转。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290020273004487.png"><img style="display: inline; border: 0px;" title="clip_image009" src="http://images.cnitblog.com/blog/383191/201501/290020333947548.png" alt="clip_image009" width="557" height="297" border="0" /></a></p>
<h2>移动</h2>
<p>坦克的移动十分容易。玩家在纵横方向的按键情况就是坦克的移动方向，速度由程序员指定，再乘上时间就好了。</p>
<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>     <span style="color: #0000ff;">void</span><span style="color: #000000;"> Update () {
</span><span style="color: #008080;"> 2</span>         <span style="color: #0000ff;">var</span> h = Input.GetAxis (<span style="color: #800000;">"</span><span style="color: #800000;">Horizontal</span><span style="color: #800000;">"</span><span style="color: #000000;">);
</span><span style="color: #008080;"> 3</span>         <span style="color: #0000ff;">var</span> v = Input.GetAxis (<span style="color: #800000;">"</span><span style="color: #800000;">Vertical</span><span style="color: #800000;">"</span><span style="color: #000000;">);
</span><span style="color: #008080;"> 4</span> 
<span style="color: #008080;"> 5</span>         <span style="color: #0000ff;">if</span> (Mathf.Abs(h) &gt; Quaternion.kEpsilon || Mathf.Abs(v) &gt;<span style="color: #000000;"> Quaternion.kEpsilon)
</span><span style="color: #008080;"> 6</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 7</span> <span style="color: #000000;">            Move (h, v);
</span><span style="color: #008080;"> 8</span> <span style="color: #000000;">        }
</span><span style="color: #008080;"> 9</span> <span style="color: #000000;">    }
</span><span style="color: #008080;">10</span> 
<span style="color: #008080;">11</span>     <span style="color: #0000ff;">void</span> Move(<span style="color: #0000ff;">float</span> h, <span style="color: #0000ff;">float</span><span style="color: #000000;"> v) 
</span><span style="color: #008080;">12</span> <span style="color: #000000;">    {
</span><span style="color: #008080;">13</span>         <span style="color: #0000ff;">var</span> moveVector = <span style="color: #0000ff;">new</span> Vector3 (h, v, <span style="color: #800080;">0</span><span style="color: #000000;">);
</span><span style="color: #008080;">14</span> <span style="color: #000000;">        moveVector.Normalize ();
</span><span style="color: #008080;">15</span>         <span style="color: #0000ff;">this</span>.transform.position += moveVector * speed *<span style="color: #000000;"> Time.deltaTime;
</span><span style="color: #008080;">16</span>     }</pre>
</div>
<p>&nbsp;</p>
<h2>底座旋转</h2>
<p>底座应该朝向移动的方向，即上文的&nbsp;<span class="cnblogs_code">moveVector</span>&nbsp;。这里用&nbsp;<span class="cnblogs_code">Quaternion.Slerp</span>&nbsp;使底座平滑地转向&nbsp;<span class="cnblogs_code">moveVector</span>&nbsp;。</p>
<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>     <span style="color: #0000ff;">void</span><span style="color: #000000;"> Update () {
</span><span style="color: #008080;"> 2</span>         <span style="color: #0000ff;">var</span> h = Input.GetAxis (<span style="color: #800000;">"</span><span style="color: #800000;">Horizontal</span><span style="color: #800000;">"</span><span style="color: #000000;">);
</span><span style="color: #008080;"> 3</span>         <span style="color: #0000ff;">var</span> v = Input.GetAxis (<span style="color: #800000;">"</span><span style="color: #800000;">Vertical</span><span style="color: #800000;">"</span><span style="color: #000000;">);
</span><span style="color: #008080;"> 4</span>         
<span style="color: #008080;"> 5</span>         <span style="color: #0000ff;">if</span> (Mathf.Abs(h) &gt; Quaternion.kEpsilon || Mathf.Abs(v) &gt;<span style="color: #000000;"> Quaternion.kEpsilon)
</span><span style="color: #008080;"> 6</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 7</span>             <span style="color: #0000ff;">this</span>.targetAngle = Mathf.Atan2(v, h) *<span style="color: #000000;"> Mathf.Rad2Deg;
</span><span style="color: #008080;"> 8</span>             <span style="color: #008000;">//</span><span style="color: #008000;">Debug.Log("target angle: " + targetAngle);</span>
<span style="color: #008080;"> 9</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">10</span>         
<span style="color: #008080;">11</span>         <span style="color: #0000ff;">this</span>.transform.rotation =<span style="color: #000000;"> Quaternion.Slerp (
</span><span style="color: #008080;">12</span>             <span style="color: #0000ff;">this</span><span style="color: #000000;">.transform.rotation,
</span><span style="color: #008080;">13</span>             Quaternion.Euler (<span style="color: #800080;">0</span>, <span style="color: #800080;">0</span><span style="color: #000000;">, targetAngle),
</span><span style="color: #008080;">14</span>             rotationSpeed *<span style="color: #000000;"> Time.deltaTime);
</span><span style="color: #008080;">15</span>     }</pre>
</div>
<p>&nbsp;</p>
<h2>炮塔旋转</h2>
<p>炮塔要指向鼠标（即目标）所在的位置，所以从炮塔到鼠标的向量就是炮塔的方向。</p>
<p><span style="color: #ff0000;">注意</span>炮塔不是围绕自身的中心旋转的，这个旋转点需要根据坦克的形状来指定。所以这里要用&nbsp;<span class="cnblogs_code">transform.RotateAround</span>&nbsp;来进行旋转。</p>
<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>     <span style="color: #0000ff;">void</span><span style="color: #000000;"> Update () {
</span><span style="color: #008080;"> 2</span>         Ray ray =<span style="color: #000000;"> Camera.main.ScreenPointToRay(Input.mousePosition);
</span><span style="color: #008080;"> 3</span> <span style="color: #000000;">        RaycastHit hit;        
</span><span style="color: #008080;"> 4</span>         <span style="color: #0000ff;">if</span>(Physics.Raycast(ray, <span style="color: #0000ff;">out</span><span style="color: #000000;"> hit))
</span><span style="color: #008080;"> 5</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 6</span>             <span style="color: #0000ff;">var</span> p =<span style="color: #000000;"> hit.point;
</span><span style="color: #008080;"> 7</span>             <span style="color: #0000ff;">var</span> y = p.y - <span style="color: #0000ff;">this</span><span style="color: #000000;">.transform.position.y;
</span><span style="color: #008080;"> 8</span>             <span style="color: #0000ff;">var</span> x = p.x - <span style="color: #0000ff;">this</span><span style="color: #000000;">.transform.position.x;
</span><span style="color: #008080;"> 9</span>             <span style="color: #0000ff;">if</span> (Mathf.Abs(y) &gt; Quaternion.kEpsilon || Mathf.Abs(x) &gt;<span style="color: #000000;"> Quaternion.kEpsilon)
</span><span style="color: #008080;">10</span> <span style="color: #000000;">            {
</span><span style="color: #008080;">11</span>                 <span style="color: #0000ff;">this</span>.targetAngle = Mathf.Atan2(y, x) *<span style="color: #000000;"> Mathf.Rad2Deg;
</span><span style="color: #008080;">12</span>                 <span style="color: #0000ff;">var</span> angle = <span style="color: #0000ff;">this</span>.targetAngle - <span style="color: #0000ff;">this</span><span style="color: #000000;">.transform.rotation.eulerAngles.z; 
</span><span style="color: #008080;">13</span> 
<span style="color: #008080;">14</span>                 <span style="color: #0000ff;">this</span>.transform.RotateAround (<span style="color: #0000ff;">this</span>.rotationCenter.position, <span style="color: #0000ff;">new</span> Vector3 (<span style="color: #800080;">0</span>, <span style="color: #800080;">0</span>, <span style="color: #800080;">1</span><span style="color: #000000;">), angle);
</span><span style="color: #008080;">15</span> <span style="color: #000000;">            }
</span><span style="color: #008080;">16</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">17</span>     }</pre>
</div>
<p>&nbsp;</p>
<h2>车轮滚动</h2>
<p>其实这不算是运动了，不过放在这一节也还算紧凑。</p>
<p>坦克移动的时候，我希望车轮下下图所示这样，显得很生动：</p>
<table border="1" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td valign="top" width="568">
<p><a href="http://images.cnitblog.com/blog/383191/201501/290020344872748.gif"><img style="display: inline;" title="clip_image010" src="http://images.cnitblog.com/blog/383191/201501/290020352227606.gif" alt="clip_image010" width="122" height="94" /></a></p>
</td>
</tr>
</tbody>
</table>
<p>我的思路是用4张图片表现车轮滚动的效果，让TankBase负责循环显示这4张图片。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290020361915535.jpg"><img style="display: inline; border: 0px;" title="clip_image012" src="http://images.cnitblog.com/blog/383191/201501/290020371446693.jpg" alt="clip_image012" width="558" height="150" border="0" /></a></p>
<p>当然，脚本可以处理任意多张图片的循环播放。其关键就是依次将各个BaseSprite的&nbsp;<span class="cnblogs_code">renderer.enabled</span>&nbsp;字段设为&nbsp;<span class="cnblogs_code"><span style="color: #0000ff;">true</span></span>&nbsp;。</p>
<div class="cnblogs_code" onclick="cnblogs_code_show('130aa9c8-2f56-455e-84fb-1c6b5a9eef41')"><img id="code_img_closed_130aa9c8-2f56-455e-84fb-1c6b5a9eef41" class="code_img_closed" src="http://images.cnblogs.com/OutliningIndicators/ContractedBlock.gif" alt="" /><img id="code_img_opened_130aa9c8-2f56-455e-84fb-1c6b5a9eef41" class="code_img_opened" style="display: none;" onclick="cnblogs_code_hide('130aa9c8-2f56-455e-84fb-1c6b5a9eef41',event)" src="http://images.cnblogs.com/OutliningIndicators/ExpandedBlockStart.gif" alt="" />
<div id="cnblogs_code_open_130aa9c8-2f56-455e-84fb-1c6b5a9eef41" class="cnblogs_code_hide">
<pre><span style="color: #008080;"> 1</span>     <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">float</span> interval = <span style="color: #800080;">10</span><span style="color: #000000;">;
</span><span style="color: #008080;"> 2</span>     <span style="color: #0000ff;">public</span> List&lt;GameObject&gt;<span style="color: #000000;"> wheels;
</span><span style="color: #008080;"> 3</span>     <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">int</span> current = <span style="color: #800080;">0</span><span style="color: #000000;">;
</span><span style="color: #008080;"> 4</span>     <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">float</span> passedInterval = <span style="color: #800080;">0</span><span style="color: #000000;">;
</span><span style="color: #008080;"> 5</span> 
<span style="color: #008080;"> 6</span>     <span style="color: #008000;">//</span><span style="color: #008000;"> Use this for initialization</span>
<span style="color: #008080;"> 7</span>     <span style="color: #0000ff;">void</span><span style="color: #000000;"> Start () {
</span><span style="color: #008080;"> 8</span>         <span style="color: #0000ff;">if</span> (wheels != <span style="color: #0000ff;">null</span> &amp;&amp; wheels.Count &gt; <span style="color: #800080;">0</span><span style="color: #000000;">)
</span><span style="color: #008080;"> 9</span>         { wheels[<span style="color: #800080;">0</span>].renderer.enabled = <span style="color: #0000ff;">true</span><span style="color: #000000;">; }
</span><span style="color: #008080;">10</span> 
<span style="color: #008080;">11</span>         <span style="color: #0000ff;">for</span> (<span style="color: #0000ff;">int</span> i = <span style="color: #800080;">1</span>; i &lt; wheels.Count; i++<span style="color: #000000;">) 
</span><span style="color: #008080;">12</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">13</span>             wheels[i].renderer.enabled = <span style="color: #0000ff;">false</span><span style="color: #000000;">;
</span><span style="color: #008080;">14</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">15</span> <span style="color: #000000;">    }
</span><span style="color: #008080;">16</span>     
<span style="color: #008080;">17</span>     <span style="color: #008000;">//</span><span style="color: #008000;"> Update is called once per frame</span>
<span style="color: #008080;">18</span>     <span style="color: #0000ff;">void</span><span style="color: #000000;"> Update () {
</span><span style="color: #008080;">19</span>         <span style="color: #0000ff;">if</span> (wheels == <span style="color: #0000ff;">null</span> || wheels.Count &lt; <span style="color: #800080;">2</span>) { <span style="color: #0000ff;">return</span><span style="color: #000000;">; }
</span><span style="color: #008080;">20</span> 
<span style="color: #008080;">21</span>         <span style="color: #0000ff;">var</span> h = Input.GetAxis (<span style="color: #800000;">"</span><span style="color: #800000;">Horizontal</span><span style="color: #800000;">"</span><span style="color: #000000;">);
</span><span style="color: #008080;">22</span>         <span style="color: #0000ff;">var</span> v = Input.GetAxis (<span style="color: #800000;">"</span><span style="color: #800000;">Vertical</span><span style="color: #800000;">"</span><span style="color: #000000;">);
</span><span style="color: #008080;">23</span>         
<span style="color: #008080;">24</span>         <span style="color: #0000ff;">if</span> (Mathf.Abs(h) &gt; Quaternion.kEpsilon || Mathf.Abs(v) &gt;<span style="color: #000000;"> Quaternion.kEpsilon)
</span><span style="color: #008080;">25</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">26</span>             passedInterval += Time.deltaTime * <span style="color: #800080;">100</span><span style="color: #000000;">;
</span><span style="color: #008080;">27</span>             <span style="color: #008000;">//</span><span style="color: #008000;">Debug.Log (passedInterval);</span>
<span style="color: #008080;">28</span>             <span style="color: #0000ff;">if</span> (passedInterval &gt;=<span style="color: #000000;"> interval)
</span><span style="color: #008080;">29</span> <span style="color: #000000;">            {
</span><span style="color: #008080;">30</span>                 <span style="color: #0000ff;">var</span> tmp =<span style="color: #000000;"> current;
</span><span style="color: #008080;">31</span> 
<span style="color: #008080;">32</span>                 <span style="color: #0000ff;">if</span> (current == wheels.Count - <span style="color: #800080;">1</span>) { current = <span style="color: #800080;">0</span><span style="color: #000000;">; }
</span><span style="color: #008080;">33</span>                 <span style="color: #0000ff;">else</span> { current++<span style="color: #000000;">; }
</span><span style="color: #008080;">34</span> 
<span style="color: #008080;">35</span>                 wheels[current].renderer.enabled = <span style="color: #0000ff;">true</span><span style="color: #000000;">;
</span><span style="color: #008080;">36</span>                 wheels[tmp].renderer.enabled = <span style="color: #0000ff;">false</span><span style="color: #000000;">;
</span><span style="color: #008080;">37</span>                 passedInterval = <span style="color: #800080;">0</span><span style="color: #000000;">;
</span><span style="color: #008080;">38</span> <span style="color: #000000;">            }
</span><span style="color: #008080;">39</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">40</span>     }</pre>
</div>
<span class="cnblogs_code_collapse">车轮滚动</span></div>
<p>&nbsp;</p>
<h1>坦克开炮</h1>
<p>这个游戏中，TankHero能够发射多种炮弹，所以需要有<span style="color: #ff0000;">多种武器</span>，每种武器发射<span style="color: #ff0000;">一种</span>炮弹。因此炮塔充当了<span style="color: #ff0000;">武器管理员</span>的角色，而不是武器本身。一种武器<span style="color: #ff0000;">决定</span>了它发射的炮弹的速度、威力等信息。这段话是武器系统的关键。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290020382533367.jpg"><img style="display: inline; border: 0px;" title="clip_image014" src="http://images.cnitblog.com/blog/383191/201501/290020398167409.jpg" alt="clip_image014" width="557" height="181" border="0" /></a></p>
<p>发射炮弹这种事，典型的方法是用&nbsp;<span class="cnblogs_code">Instantiate</span>&nbsp;。这就需要在场景中持有一个现成的炮弹。如下图所示：</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290020408315054.jpg"><img style="display: inline; border: 0px;" title="clip_image016" src="http://images.cnitblog.com/blog/383191/201501/290020417376496.jpg" alt="clip_image016" width="558" height="277" border="0" /></a></p>
<p>这个炮弹要永远存在，还不能被摄像机看到，所以我们把它放到之前说的地面背景的更后面。</p>
<p>你注意到图中的炮弹中心有个比较小的绿色的圈，这个圈是Circle Collider 2D，是用来产生碰撞的。我刻意把这个Collider调到这么小，是为了避免在坦克刚刚发射出炮弹时，炮弹与自身产生碰撞（即自己开炮瞬间<span style="color: #ff0000;">打了自己</span>）。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290020473629714.png"><img style="display: inline; border: 0px;" title="clip_image017" src="http://images.cnitblog.com/blog/383191/201501/290020530666191.png" alt="clip_image017" width="562" height="286" border="0" /></a></p>
<p>同时，在上图中我用黄色圈圈出了那个BulletPosition的gameobject，这是专门用来指定<span style="color: #ff0000;">炮弹产生点</span>的，也是为了避免炮弹刚刚发射出来就把自己给打了。</p>
<p>注意，带2D的Collider似乎有这样的问题：无论在Z方向上是否在同一Z平面，都能引发碰撞事件。所以，那个永生的炮弹，虽然藏到地面背景后方去了，却仍旧可能与游戏中的其它物体发生碰撞（然后就会爆炸消失被Destroy掉，之后就无法再用Instantiate来创建炮弹了）。为了避免它的&nbsp;<span class="cnblogs_code">Destroy</span>&nbsp;，我们需要将它和其它炮弹区别开来，所以就必须给炮弹对象添加一个&nbsp;<span class="cnblogs_code">undying</span>&nbsp;字段，让&nbsp;<span class="cnblogs_code">undying</span>&nbsp;为true的炮弹在触发了碰撞事件时也不爆炸消失。</p>
<h1>摄像机随主角移动</h1>
<p>我希望地图能够大一点，所以一屏肯定放不下。所以需要摄像机随主角坦克的移动而移动。这个很容易，不断跟随主角坦克就行了。</p>
<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>     <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">float</span> catchingSpeed = <span style="color: #800080;">1</span><span style="color: #000000;">;
</span><span style="color: #008080;"> 2</span>     <span style="color: #0000ff;">private</span><span style="color: #000000;"> Transform tankHero;
</span><span style="color: #008080;"> 3</span> 
<span style="color: #008080;"> 4</span>     <span style="color: #0000ff;">void</span><span style="color: #000000;"> Awake()
</span><span style="color: #008080;"> 5</span> <span style="color: #000000;">    {
</span><span style="color: #008080;"> 6</span>         <span style="color: #0000ff;">this</span>.tankHero =<span style="color: #000000;"> GameObject.FindGameObjectWithTag (Tags.hero).transform;
</span><span style="color: #008080;"> 7</span> <span style="color: #000000;">    }
</span><span style="color: #008080;"> 8</span>     <span style="color: #0000ff;">void</span><span style="color: #000000;"> Update () {
</span><span style="color: #008080;"> 9</span>         <span style="color: #0000ff;">var</span> targetPosition = <span style="color: #0000ff;">new</span> Vector3 (<span style="color: #0000ff;">this</span>.tankHero.position.x, <span style="color: #0000ff;">this</span>.tankHero.position.y, <span style="color: #0000ff;">this</span><span style="color: #000000;">.transform.position.z);
</span><span style="color: #008080;">10</span>         <span style="color: #0000ff;">this</span>.transform.position = Vector3.Lerp (<span style="color: #0000ff;">this</span>.transform.position, targetPosition, Time.deltaTime * <span style="color: #0000ff;">this</span><span style="color: #000000;">.catchingSpeed);
</span><span style="color: #008080;">11</span>     }</pre>
</div>
<p>注意这里将&nbsp;<span class="cnblogs_code">catchingSpeed</span>&nbsp;调低一些，会产生摄像机<span style="color: #ff0000;">延迟跟随</span>主角坦克的现象。我很喜欢这种跟随的感觉，柔和不生硬，而且还解决了后文遇到的一个问题。</p>
<h1>自定义鼠标样式</h1>
<p>我希望鼠标在游戏中显示为下图所示的样子，很带感。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290020595345768.png"><img style="display: inline; border: 0px;" title="clip_image018" src="http://images.cnitblog.com/blog/383191/201501/290021061286916.png" alt="clip_image018" width="457" height="310" border="0" /></a></p>
<p>方法有两种。</p>
<h2>Default cursor</h2>
<p>一是在File &ndash; Build Settings &ndash; Player Settings打开的Inspector面板中设置Default Cursor。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290021081288260.jpg"><img style="display: inline; border: 0px;" title="clip_image020" src="http://images.cnitblog.com/blog/383191/201501/290021100199103.jpg" alt="clip_image020" width="558" height="267" border="0" /></a></p>
<p>这个方法有点问题，首先在build之后的exe中你可能发现鼠标<span style="color: #ff0000;">彻底消失</span>了，既没有原始图标也没有自定义图标，其次在你修改了自定义图标之后，可能会显示成一个很<span style="color: #ff0000;">奇怪</span>的图标，最后，这样自定义的图标，其<span style="color: #ff0000;">清晰度</span>大打折扣，其<span style="color: #ff0000;">size</span>也是固定的。</p>
<p>所以我推荐另一种方法，即用脚本实现。</p>
<h2>脚本实现</h2>
<p>典型的实现方式是这样的，在主摄像机上添加一个TargetCusor.cs的脚本（脚本名无所谓），编写代码如下：</p>
<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>     <span style="color: #008000;">//</span><span style="color: #008000;">3D贴图是Material,2D贴图是Texture</span>
<span style="color: #008080;"> 2</span>     <span style="color: #0000ff;">public</span><span style="color: #000000;"> Texture CurosrTexture;
</span><span style="color: #008080;"> 3</span>     <span style="color: #0000ff;">void</span> OnGUI() { <span style="color: #008000;">//</span><span style="color: #008000;">    渲染GUI和处理GUI时调用。</span>
<span style="color: #008080;"> 4</span>         <span style="color: #0000ff;">if</span> (CurosrTexture != <span style="color: #0000ff;">null</span><span style="color: #000000;">) {
</span><span style="color: #008080;"> 5</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> 计算图片左上角的坐标</span>
<span style="color: #008080;"> 6</span>             <span style="color: #0000ff;">float</span> left = Input.mousePosition.x - CurosrTexture.width / <span style="color: #800080;">2</span><span style="color: #000000;">;
</span><span style="color: #008080;"> 7</span>             <span style="color: #0000ff;">float</span> top = Screen.height - Input.mousePosition.y - CurosrTexture.height / <span style="color: #800080;">2</span><span style="color: #000000;">;
</span><span style="color: #008080;"> 8</span>             
<span style="color: #008080;"> 9</span>             GUI.DrawTexture(<span style="color: #0000ff;">new</span><span style="color: #000000;"> Rect(left, top, CurosrTexture.width, CurosrTexture.height), CurosrTexture);
</span><span style="color: #008080;">10</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">11</span>     }</pre>
</div>
<p>在Inspector面板中指定你的图标即可。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290021120034677.jpg"><img style="display: inline; border: 0px;" title="clip_image022" src="http://images.cnitblog.com/blog/383191/201501/290021140344265.jpg" alt="clip_image022" width="558" height="257" border="0" /></a></p>
<h1>围墙</h1>
<p>限制坦克和炮弹的活动范围是必须的。这里我暂且简单地制作一个正方形围墙。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290021195032969.png"><img style="display: inline; border: 0px;" title="clip_image023" src="http://images.cnitblog.com/blog/383191/201501/290021250503930.png" alt="clip_image023" width="515" height="287" border="0" /></a></p>
<p>这个围墙由四个quad组成。绿色的线条是Box Collider 2D组件。围墙的功能就是把撞上它的东西（坦克、炮弹等）弹回去。这里不得不用一个&nbsp;<span class="cnblogs_code">Dictionary&lt;Collider2D, Vector3&gt;</span>&nbsp;字典记录撞到围墙的物体在碰撞瞬间的位置，因为之后要将物体弹回这个位置。</p>
<div class="cnblogs_code" onclick="cnblogs_code_show('6f4d275c-9d4b-427e-8af7-863efcec7e66')"><img id="code_img_closed_6f4d275c-9d4b-427e-8af7-863efcec7e66" class="code_img_closed" src="http://images.cnblogs.com/OutliningIndicators/ContractedBlock.gif" alt="" /><img id="code_img_opened_6f4d275c-9d4b-427e-8af7-863efcec7e66" class="code_img_opened" style="display: none;" onclick="cnblogs_code_hide('6f4d275c-9d4b-427e-8af7-863efcec7e66',event)" src="http://images.cnblogs.com/OutliningIndicators/ExpandedBlockStart.gif" alt="" />
<div id="cnblogs_code_open_6f4d275c-9d4b-427e-8af7-863efcec7e66" class="cnblogs_code_hide">
<pre><span style="color: #008080;"> 1</span> <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">class</span><span style="color: #000000;"> PushBackToField : MonoBehaviour {
</span><span style="color: #008080;"> 2</span>     Dictionary&lt;Collider2D, Vector3&gt; initialPositionDict;<span style="color: #008000;">//</span><span style="color: #008000;"> = new Dictionary&lt;Collider, Vector3&gt;();</span>
<span style="color: #008080;"> 3</span> 
<span style="color: #008080;"> 4</span>     <span style="color: #0000ff;">void</span><span style="color: #000000;"> Awake()
</span><span style="color: #008080;"> 5</span> <span style="color: #000000;">    {
</span><span style="color: #008080;"> 6</span>         initialPositionDict = <span style="color: #0000ff;">new</span> Dictionary&lt;Collider2D, Vector3&gt;<span style="color: #000000;"> ();
</span><span style="color: #008080;"> 7</span> <span style="color: #000000;">    }
</span><span style="color: #008080;"> 8</span> 
<span style="color: #008080;"> 9</span>     <span style="color: #0000ff;">void</span><span style="color: #000000;"> OnTriggerEnter2D(Collider2D other)
</span><span style="color: #008080;">10</span> <span style="color: #000000;">    {
</span><span style="color: #008080;">11</span>         <span style="color: #0000ff;">if</span><span style="color: #000000;"> (initialPositionDict.ContainsKey(other))
</span><span style="color: #008080;">12</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">13</span>             initialPositionDict[other] =<span style="color: #000000;"> other.transform.position;
</span><span style="color: #008080;">14</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">15</span>         <span style="color: #0000ff;">else</span>
<span style="color: #008080;">16</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">17</span> <span style="color: #000000;">            initialPositionDict.Add(other, other.transform.position);
</span><span style="color: #008080;">18</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">19</span> <span style="color: #000000;">    }
</span><span style="color: #008080;">20</span>     
<span style="color: #008080;">21</span>     <span style="color: #0000ff;">void</span><span style="color: #000000;"> OnTriggerStay2D(Collider2D other)
</span><span style="color: #008080;">22</span> <span style="color: #000000;">    {
</span><span style="color: #008080;">23</span> <span style="color: #000000;">        Push (other);
</span><span style="color: #008080;">24</span> <span style="color: #000000;">    }
</span><span style="color: #008080;">25</span>     
<span style="color: #008080;">26</span>     <span style="color: #0000ff;">void</span><span style="color: #000000;"> OnTriggerExit2D(Collider2D other)
</span><span style="color: #008080;">27</span> <span style="color: #000000;">    {
</span><span style="color: #008080;">28</span>         <span style="color: #0000ff;">if</span><span style="color: #000000;"> (initialPositionDict.ContainsKey(other))
</span><span style="color: #008080;">29</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">30</span> <span style="color: #000000;">            initialPositionDict.Remove(other);
</span><span style="color: #008080;">31</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">32</span> <span style="color: #000000;">    }
</span><span style="color: #008080;">33</span>     
<span style="color: #008080;">34</span>     <span style="color: #0000ff;">void</span><span style="color: #000000;"> Push(Collider2D other)
</span><span style="color: #008080;">35</span> <span style="color: #000000;">    {
</span><span style="color: #008080;">36</span>         Vector3 initialPosition =<span style="color: #000000;"> Vector3.zero;
</span><span style="color: #008080;">37</span>         <span style="color: #0000ff;">if</span><span style="color: #000000;"> (initialPositionDict.ContainsKey(other))
</span><span style="color: #008080;">38</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">39</span>             initialPosition =<span style="color: #000000;"> initialPositionDict[other];
</span><span style="color: #008080;">40</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">41</span>         <span style="color: #0000ff;">else</span>
<span style="color: #008080;">42</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">43</span>             Debug.LogError(<span style="color: #0000ff;">string</span>.Format(<span style="color: #800000;">"</span><span style="color: #800000;">{0} should have been added to the dict.</span><span style="color: #800000;">"</span><span style="color: #000000;">, other.gameObject.name));
</span><span style="color: #008080;">44</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">45</span>         
<span style="color: #008080;">46</span>         <span style="color: #0000ff;">if</span> ((initialPosition - other.transform.position).magnitude &gt; <span style="color: #800080;">0.001f</span><span style="color: #000000;">)
</span><span style="color: #008080;">47</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">48</span>             <span style="color: #008000;">//</span><span style="color: #008000;">Debug.Log("lerp push");</span>
<span style="color: #008080;">49</span>             other.transform.position =<span style="color: #000000;"> Vector3.Lerp(other.transform.position, Vector3.zero, Time.deltaTime);
</span><span style="color: #008080;">50</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">51</span>         <span style="color: #0000ff;">else</span>
<span style="color: #008080;">52</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">53</span>             <span style="color: #008000;">//</span><span style="color: #008000;">Debug.Log("sudden push");</span>
<span style="color: #008080;">54</span>             other.transform.position =<span style="color: #000000;"> initialPosition;
</span><span style="color: #008080;">55</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">56</span> <span style="color: #000000;">    }
</span><span style="color: #008080;">57</span> }</pre>
</div>
<span class="cnblogs_code_collapse">围墙</span></div>
<p>这个脚本对上下左右四个围墙都适用，以后有了别的形状的围墙，也仍然适用。这也是它的优点之一。</p>
<p>说到这个围墙的反弹，就涉及摄像机跟随的一个问题。实际上，围墙反弹时，如果玩家<span style="color: #ff0000;">持续撞击</span>围墙，会使玩家坦克产生快速的震动。此时摄像机也就跟着快速震动，这很影响体验。上文里将跟随速度设置得比较低时，这种震动就不会影响到摄像机。这是因为，摄像机反应慢，震动速度快，不等摄像机需要向左跟随，就又要向右跟随了，所以摄像机基本上就在原地不动了。</p>
<p>将上文的&nbsp;<span class="cnblogs_code">catchingSpeed</span>&nbsp;调大一些，再持续去撞墙，你就会明白了。</p>
<h1>光源</h1>
<p>忘了说，要添加一个线光源，不然场景会很暗淡。下图就是没有添加光源的样子。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290021295039690.png"><img style="display: inline; border: 0px;" title="clip_image024" src="http://images.cnitblog.com/blog/383191/201501/290021332064822.png" alt="clip_image024" width="552" height="258" border="0" /></a></p>
<p>加上光源就成了这样：</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290021404251327.png"><img style="display: inline; border: 0px;" title="clip_image025" src="http://images.cnitblog.com/blog/383191/201501/290021462372602.png" alt="clip_image025" width="541" height="245" border="0" /></a></p>
<h1>显示文字</h1>
<p>想显示上图所示的文字？用Unity最近推出的uGUI还是很舒服的（也可能是因为我没有学过nGUI等等的UI系统吧）。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290021473161032.png"><img style="display: inline; border: 0px;" title="clip_image026" src="http://images.cnitblog.com/blog/383191/201501/290021483782690.png" alt="clip_image026" width="378" height="431" border="0" /></a></p>
<p>点击Text后，会增加3个对象，Canvas，Text和EventSystem。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290021491758333.jpg"><img style="display: inline; border: 0px;" title="clip_image028" src="http://images.cnitblog.com/blog/383191/201501/290021500664005.jpg" alt="clip_image028" width="558" height="128" border="0" /></a></p>
<p>给Text对象添加一个<strong>DrawMouseInfo.cs</strong>的组件（名字无所谓）。</p>
<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span> <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">class</span><span style="color: #000000;"> DrawMouseInfo : MonoBehaviour {
</span><span style="color: #008080;"> 2</span> <span style="color: #000000;">    Text guiText;
</span><span style="color: #008080;"> 3</span> 
<span style="color: #008080;"> 4</span>     <span style="color: #0000ff;">void</span><span style="color: #000000;"> Awake()
</span><span style="color: #008080;"> 5</span> <span style="color: #000000;">    {
</span><span style="color: #008080;"> 6</span>         guiText = <span style="color: #0000ff;">this</span>.GetComponent&lt;Text&gt;<span style="color: #000000;"> ();
</span><span style="color: #008080;"> 7</span> <span style="color: #000000;">    }
</span><span style="color: #008080;"> 8</span> 
<span style="color: #008080;"> 9</span>     <span style="color: #0000ff;">void</span><span style="color: #000000;"> Update () {
</span><span style="color: #008080;">10</span>         Ray ray =<span style="color: #000000;"> Camera.main.ScreenPointToRay(Input.mousePosition);
</span><span style="color: #008080;">11</span> <span style="color: #000000;">        RaycastHit hit;        
</span><span style="color: #008080;">12</span>         <span style="color: #0000ff;">if</span>(Physics.Raycast(ray, <span style="color: #0000ff;">out</span><span style="color: #000000;"> hit))
</span><span style="color: #008080;">13</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">14</span>             guiText.text = <span style="color: #0000ff;">string</span>.Format (<span style="color: #800000;">"</span><span style="color: #800000;">input: {0} mouse: {1} | {2}</span><span style="color: #800000;">"</span><span style="color: #000000;">, Input.mousePosition, hit.point, hit.transform.gameObject.name);
</span><span style="color: #008080;">15</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">16</span>         <span style="color: #0000ff;">else</span>
<span style="color: #008080;">17</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">18</span>             guiText.text = <span style="color: #0000ff;">string</span>.Format (<span style="color: #800000;">"</span><span style="color: #800000;">input: {0} mouse: {1} | {2}</span><span style="color: #800000;">"</span>, Input.mousePosition, <span style="color: #800000;">"</span><span style="color: #800000;">null</span><span style="color: #800000;">"</span>, <span style="color: #800000;">"</span><span style="color: #800000;">null</span><span style="color: #800000;">"</span><span style="color: #000000;">);
</span><span style="color: #008080;">19</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">20</span> <span style="color: #000000;">    }
</span><span style="color: #008080;">21</span> }</pre>
</div>
<p>uGUI对象是可以在Scene视图里拖动的，只不过你要先找到它。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290021509721149.jpg"><img style="display: inline; border: 0px;" title="clip_image030" src="http://images.cnitblog.com/blog/383191/201501/290021517848264.jpg" alt="clip_image030" width="558" height="273" border="0" /></a></p>
<p>它的位置很奇葩，如上图所示，整个地图在它的Canvas脚下都很渺小。</p>
<h1>快速自制贴图资源</h1>
<p>本项目中的坦克、子弹、光标、背景图都是本人制作的，制作工具你猜猜？是<span style="color: #ff0000;">PPT</span>。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290021538471394.jpg"><img style="display: inline; border: 0px;" title="clip_image032" src="http://images.cnitblog.com/blog/383191/201501/290021560345496.jpg" alt="clip_image032" width="558" height="386" border="0" /></a></p>
<p>坦克底座是<span style="color: #ff0000;">SmartArt</span>图形里的。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290021578165839.jpg"><img style="display: inline; border: 0px;" title="clip_image034" src="http://images.cnitblog.com/blog/383191/201501/290021598167183.jpg" alt="clip_image034" width="558" height="296" border="0" /></a></p>
<p>轮子只是设置了一下<span style="color: #ff0000;">渐变填充</span>。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290022012696427.jpg"><img style="display: inline; border: 0px;" title="clip_image036" src="http://images.cnitblog.com/blog/383191/201501/290022032697772.jpg" alt="clip_image036" width="558" height="371" border="0" /></a></p>
<p>炮塔的圆形，把底座的圆形缩小一点就是。炮塔的炮管，是&ldquo;形状&rdquo;里的<span style="color: #ff0000;">箭头</span>，删掉凸起的尖的部分，调整一下锚点长短就OK。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290022039417143.png"><img style="display: inline; border: 0px;" title="clip_image037" src="http://images.cnitblog.com/blog/383191/201501/290022045813974.png" alt="clip_image037" width="265" height="86" border="0" /></a></p>
<p>背景用的是&ldquo;<span style="color: #ff0000;">纹理填充</span>&rdquo;，看到第二行第一个了没？</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290022088785220.png"><img style="display: inline; border: 0px;" title="clip_image038" src="http://images.cnitblog.com/blog/383191/201501/290022145195209.png" alt="clip_image038" width="488" height="470" border="0" /></a></p>
<p>准星，用的是SmartArt里的&ldquo;<span style="color: #ff0000;">分离射线</span>&rdquo;。把四个箭头留下，其它内容删除。再把箭头的尾部顶点删除，左右交换位置，上下交换位置，上个色就成了。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290022163475268.jpg"><img style="display: inline; border: 0px;" title="clip_image040" src="http://images.cnitblog.com/blog/383191/201501/290022185349370.jpg" alt="clip_image040" width="558" height="296" border="0" /></a></p>
<p><a href="http://images.cnitblog.com/blog/383191/201501/290022208167799.png"><img style="display: inline; border: 0px;" title="clip_image041" src="http://images.cnitblog.com/blog/383191/201501/290022226599330.png" alt="clip_image041" width="444" height="407" border="0" /></a></p>
<p>还可以吧？</p>
<h1>总结</h1>
<p>您可以到我的github页面（<a href="https://github.com/bitzhuwei/TankHero-2D" target="_blank">https://github.com/bitzhuwei/TankHero-2D</a>）上得到工程源码。</p>
<p>请多多指教~</p>
