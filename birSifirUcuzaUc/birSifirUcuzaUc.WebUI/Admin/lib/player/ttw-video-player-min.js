/**
 * Created by 23rd and Walnut for Codebasehero.com
 * www.23andwalnut.com
 * www.codebasehero.com
 * User: Saleem El-Amin
 * Date: 7/20/11
 * Time: 6:41 AM
 *
 * Version: 1.00
 * License: You are free to use this file in personal and commercial products, however re-distribution 'as-is' without prior consent is prohibited.
 */
(function(a){a.fn.ttwVideoPlayer=function(b){var d,e=this.data("ttwVideoPlayer");if(typeof e!=="undefined"&&e.api[b]){var c=Array.prototype.slice.call(arguments,1);return e.api[b].apply(this,c)}else{if(typeof b==="object"){this.addClass("ttwVideoPlayer");e=new a.ttwVideoPlayer(this,b,arguments[1]);this.data("ttwMediaBox",e);return this}else{a.error(b+" is not a valid method or playlist for ttwVideoPlayer")}}};a.ttwVideoPlayer=function(l,t,g){var s=l,o=this,x,f,h,v,d,i,t,w,p,q,c=false,n={},m,A,y;h={main:".ttw-video-player ",jPlayer:"#jquery_jplayer",jPlayerContainer:".jPlayer-container",jPlayerInterface:".jp-interface",playerPrevious:".jp-interface .jp-previous",playerNext:".jp-interface .jp-next",playlist:".playlist",playlistItems:".playlist-items",playlistItem:".playlist-item",playing:".playing",player:".player",progress:".progress-wrapper",volume:".volume-wrapper",playerControls:".player-controls",playlistButton:".playlist-button",hdButton:".hd-button",heartButton:".heart-button",settingsButton:".settings-button",fullscreenButton:".fullscreen-button",heartCount:".heart-count",scrollViewport:".viewport"};m=["playlist","hd","heart","settings","fullscreen"];x={autoplay:false,autoHidePlaylist:true,autoHidePlaylistDelay:3000,jPlayer:{},buttons:["playlist","hd","heart","settings"],width:"554px",height:"312px",allowHeartIncrement:function(){return true}};this.heartCount=0;this.api={updateHeartCount:function(){w.updateHeartCount()}};f=a.extend(true,{},x,g);p=t;q=0;v=function(){b("Starting");t=new d();w=new i();w.buildInterface();t.init(f.jPlayer);s.bind("mbPlaylistLoaded",function(){w.init()})};d=function(){var H=false;function I(K){n=a(h.main).find(".jPlayer-container");A={swfPath:"jquery-jplayer",supplied:"mp3, m4a, m4v, oga, ogv, wav",cssSelectorAncestor:h.jPlayerInterface,errorAlerts:false,warningAlerts:false,size:{height:f.height,width:f.width,cssClass:"show-video"},sizeFull:{width:"100%",height:"90%",cssClass:"show-video-full"}};y=a.extend(true,{},A,K);n.bind(a.jPlayer.event.ready,function(){b("jPlayer Ready");n.bind(a.jPlayer.event.ended,function(L){G()});n.bind(a.jPlayer.event.play,function(L){n.jPlayer("pauseOthers")});n.bind(a.jPlayer.event.playing,function(L){H=true});n.bind(a.jPlayer.event.pause,function(L){H=false});a(h.playerPrevious).click(function(){F();a(this).blur();return false});a(h.playerNext).click(function(){G();a(this).blur();return false});s.bind("mbInitPlaylistAdvance",function(L,M){if(M!=q){q=M;B(q)}else{if(!n.data("jPlayer").status.srcSet){B(0)}else{J()}}});s.bind("mbInitPlayMedia",function(M,L){C(L)});s.trigger("mbPlaylistLoaded");E(f.autoplay)});n.jPlayer(y)}function E(K){q=0;if(K){B(q)}else{D(q);s.trigger("mbPlaylistInit")}}function D(K){q=K;n.jPlayer("setMedia",p[q])}function B(K){D(K);s.trigger("mbPlaylistAdvance");n.jPlayer("play")}function C(K){n.jPlayer("setMedia",K);s.trigger("mbPlaylistAdvance");n.jPlayer("play")}function G(){var K=(q+1<p.length)?q+1:0;B(K)}function F(){var K=(q-1>=0)?q-1:p.length-1;B(K)}function J(){if(!H){n.jPlayer("play")}else{n.jPlayer("pause")}}return{init:I,playlistInit:E,playlistAdvance:B,playlistNext:G,playlistPrev:F,togglePlay:J,$myJplayer:n}};i=function(){var F,I,B;function J(){F=a(h.player),I=a(h.playlist);D();H()}function G(){var N,T,O,M,S,Q,P,R;N='<div class="ttw-video-player"><div class="jPlayer-container"></div><div class="player jp-interface"><div class="player-controls"><div class="play jp-play button"></div><div class="pause jp-pause button"></div><div class="separator"></div><div class="playlist-button button"></div><div class="separator"></div><div class="hd-button button"></div><div class="separator"></div><div class="progress-wrapper"><div class="progress-bg"><div class="progress jp-seek-bar"><div class="elapsed jp-play-bar"></div></div></div></div><div class="separator"></div><div class="volume-wrapper"><div class="volume jp-volume-bar"><div class="volume-value jp-volume-bar-value"></div></div></div><div class="separator"></div><div class="heart-button button"></div><div class="heart-count"></div><div class="separator"></div><div class="settings-button button"></div><div class="separator"></div><div class="fullscreen-button  button"></div></div><!-- These controls aren\'t used by this plugin, but jPlayer seems to require that they exist --><span class="unused-controls"><span class="previous jp-previous"></span><span class="next jp-next"></span><span class="jp-video-play"></span><span class="jp-stop"></span><span class="jp-mute"></span><span class="jp-unmute"></span><span class="jp-volume-max"></span><span class="jp-current-time"></span><span class="jp-duration"></span><span class="jp-repeat"></span><span class="jp-repeat-off"></span><span class="jp-gui"></span><span class="jp-restore-screen"></span><span class="jp-full-screen"></span></span></div><div class="playlist"><div class="viewport"><ol class="scroll-content playlist-items"></ol></div><div class="scrollbar"><div class="track"><div class="thumb"><div class="end"></div></div></div></div><div class="clear"></div></div></div>';T=a(N).css({display:"none",opacity:0}).appendTo(s).slideDown("slow",function(){T.width(f.width).find(h.jPlayerInterface+", "+h.jPlayerContainer).width(f.width);T.height(j(f.height)).find(h.jPlayerContainer).height(j(f.height)-34);T.animate({opacity:1},200,function(){s.trigger("mbInterfaceBuilt");for(var U=0;U<m.length;U++){if(a.inArray(m[U],f.buttons)==-1){T.find(h[m[U]+"Button"]).css("display","none").next(".separator").css("display","none")}}if(a.inArray("fullscreen",f.buttons)!=-1){R="fullscreen"}else{if(a.inArray("settings",f.buttons)!=-1){R="settings"}else{if(a.inArray("heart",f.buttons)!=-1){R="heart"}else{R="volume"}}}if(R!="volume"){T.find(h[R+"Button"]).next(".separator").css("display","none")}else{T.find(h.volume).next(".separator").css("display","none")}M=f.width.substr(0,f.width.length-2);S=((f.buttons.length+1)*34);Q=T.find(h.volume).outerWidth()+2;P=20;O=M-S-Q-P;T.find(h.progress).width(O);if(a.inArray("heart",f.buttons)!=-1){T.find(h.heartCount).css({left:T.find(h.heartButton).position()["left"]-10})}})})}function C(M){if(I.hasClass("showing")){M.removeClass("pressed");I.stop().removeClass("showing").animate({opacity:0},200,function(){a(this).css("display","none")})}else{M.addClass("pressed");I.stop().css({opactiy:0,display:"block"}).addClass("showing").animate({opacity:1},200);if(f.autoHidePlaylist){L(M)}}}function H(){var M=s.find(h.playerControls);M.find(h.playlistButton).bind("click",function(){clearTimeout(B);C(a(this));u(f.playlistButtonCallback)});M.find(h.hdButton).bind("click",function(){if(f.hdPlaylist&&f.hdPlaylist[q]){s.trigger("mbInitPlayMedia",[f.hdPlaylist[q]])}u(f.hdButtonCallback)});M.find(h.heartButton).bind("click",function(N){if(u(f.allowHeartIncrement,N)===true){o.heartCount++;K();u(f.heartButtonCallback,o.heartCount)}});M.find(h.settingsButton).bind("click",function(N){u(f.settingsButtonCallback)});M.find(h.fullscreenButton).bind("click",function(N){u(f.fullscreenCallback)})}function D(){var M,P,O;M={listItem:'<li class="playlist-item"></li>'};O=s.find(h.playlistItems);for(var N=0;N<p.length;N++){var Q=a(M.listItem);Q.data("index",N);if(!e(p[N].poster)){a('<img src="'+p[N].poster+'" alt="video poster" />').css({opacity:0}).appendTo(Q).imagesLoaded(function(){a(this).animate({opacity:1})})}else{Q.html(k(N))}O.append(Q)}s.find(h.playlistItem).click(function(){s.trigger("mbInitPlaylistAdvance",[a(this).data("index")])});O.parents(h.playlist).height(j(f.height)-34).find(h.scrollViewport).height(j(f.height)-34);P=O.parents(h.playlist).tinyscrollbar({sizethumb:114}).css("display","none");if(f.autoHidePlaylist){P.mouseleave(function(){L(s.find(h.playlistButton))});P.mouseenter(function(){clearTimeout(B)})}}function L(M){B=setTimeout(function(){C(M)},f.autoHidePlaylistDelay)}function E(M){return !e(p[M].duration)?p[M].duration:"-"}function K(){if(o.heartCount>0){var M=s.find(h.heartCount);if(o.heartCount==1){M.css({opacity:0,display:"block"}).addClass("showing").animate({opacity:1})}M.html(o.heartCount)}}return{buildInterface:G,buildPlaylist:D,updateHeartCount:K,init:J}};function j(B){return parseInt(B.substr(0,B.length-2))}function b(B){if(f.debug&&window.console){console.log("MEDIA PLAYER: "+B)}}function k(C){if(!e(p[C].title)){return p[C].title}else{var B="",E=y.supplied.split(",");for(var D=0;D<E.length;D++){E[D]=a.trim(E[D]);if(!e(p[C][E[D]])){B=z(p[C][E[D]]);break}}return B}}function z(B){B=B.split("/");return B[B.length-1]}function r(B){return B.substr(1)}function u(C){var B=Array.prototype.slice.call(arguments,1);if(a.isFunction(C)){return C.apply(this,B)}else{return false}}function e(B){return typeof B=="undefined"}v()}})(jQuery);
/*!
 * Tiny Scrollbar 1.65
 * http://www.baijs.nl/tinyscrollbar/
 *
 * Copyright 2010, Maarten Baijs
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://www.opensource.org/licenses/mit-license.php
 * http://www.opensource.org/licenses/gpl-2.0.php
 *
 * Date: 10 / 05 / 2011
 * Depends on library: jQuery
 *
 */
(function(a){a.tiny=a.tiny||{};a.tiny.scrollbar={options:{axis:"y",wheel:40,scroll:true,size:"auto",sizethumb:"auto"}};a.fn.tinyscrollbar=function(c){var c=a.extend({},a.tiny.scrollbar.options,c);this.each(function(){a(this).data("tsb",new b(a(this),c))});return this};a.fn.tinyscrollbar_update=function(c){return a(this).data("tsb").update(c)};function b(p,f){var j=this;var s=p;var i={obj:a(".viewport",p)};var g={obj:a(".scroll-content",p)};var d={obj:a(".scrollbar",p)};var l={obj:a(".track",d.obj)};var o={obj:a(".thumb",d.obj)};var k=f.axis=="x",m=k?"left":"top",u=k?"Width":"Height";var q,x={start:0,now:0},n={};function c(){j.update();r();return j}this.update=function(y){i[f.axis]=i.obj[0]["offset"+u];g[f.axis]=g.obj[0]["scroll"+u];g.ratio=i[f.axis]/g[f.axis];d.obj.toggleClass("disable",g.ratio>=1);l[f.axis]=f.size=="auto"?i[f.axis]:f.size;o[f.axis]=Math.min(l[f.axis],Math.max(0,(f.sizethumb=="auto"?(l[f.axis]*g.ratio):f.sizethumb)));d.ratio=f.sizethumb=="auto"?(g[f.axis]/l[f.axis]):(g[f.axis]-i[f.axis])/(l[f.axis]-o[f.axis]);q=(y=="relative"&&g.ratio<=1)?Math.min((g[f.axis]-i[f.axis]),Math.max(0,q)):0;q=(y=="bottom"&&g.ratio<=1)?(g[f.axis]-i[f.axis]):isNaN(parseInt(y))?q:parseInt(y);v()};function v(){o.obj.css(m,q/d.ratio);g.obj.css(m,-q);n.start=o.obj.offset()[m];var y=u.toLowerCase();d.obj.css(y,l[f.axis]);l.obj.css(y,l[f.axis]);o.obj.css(y,o[f.axis])}function r(){o.obj.bind("mousedown",h);o.obj[0].ontouchstart=function(y){y.preventDefault();o.obj.unbind("mousedown");h(y.touches[0]);return false};l.obj.bind("mouseup",t);if(f.scroll&&this.addEventListener){s[0].addEventListener("DOMMouseScroll",w,false);s[0].addEventListener("mousewheel",w,false)}else{if(f.scroll){s[0].onmousewheel=w}}}function h(z){n.start=k?z.pageX:z.pageY;var y=parseInt(o.obj.css(m));x.start=y=="auto"?0:y;a(document).bind("mousemove",t);document.ontouchmove=function(A){a(document).unbind("mousemove");t(A.touches[0])};a(document).bind("mouseup",e);o.obj.bind("mouseup",e);o.obj[0].ontouchend=document.ontouchend=function(A){a(document).unbind("mouseup");o.obj.unbind("mouseup");e(A.touches[0])};return false}function w(z){if(!(g.ratio>=1)){z=a.event.fix(z||window.event);var y=z.wheelDelta?z.wheelDelta/120:-z.detail/3;q-=y*f.wheel;q=Math.min((g[f.axis]-i[f.axis]),Math.max(0,q));o.obj.css(m,q/d.ratio);g.obj.css(m,-q);z.preventDefault()}}function e(y){a(document).unbind("mousemove",t);a(document).unbind("mouseup",e);o.obj.unbind("mouseup",e);document.ontouchmove=o.obj[0].ontouchend=document.ontouchend=null;return false}function t(y){if(!(g.ratio>=1)){x.now=Math.min((l[f.axis]-o[f.axis]),Math.max(0,(x.start+((k?y.pageX:y.pageY)-n.start))));q=x.now*d.ratio;g.obj.css(m,-q);o.obj.css(m,x.now)}return false}return c()}})(jQuery);(function(a){a.fn.imagesLoaded=function(d){var c=this.filter("img"),b=c.length;c.bind("load",function(){if(--b<=0){d.call(c,this)}}).each(function(){if(this.complete||this.complete===undefined){var e=this.src;this.src="data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///ywAAAAAAQABAAACAUwAOw==";this.src=e}});return this}})(jQuery);