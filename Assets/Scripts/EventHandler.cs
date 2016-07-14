﻿using System;

//ManagerMzMasterの各ステートで処理されるイベント
public delegate void EveHandMgrState(object sender, EventArgs e);
//ManagerMzMasterのステート移動の際のイベント
public delegate void EveHandMoveState(object sender, EventArgs e);
//SEサウンドを鳴らす為のイベント
public delegate void EveHandPLAYSE(object sender, EventArgs e);
//テキスト削除用のイベント
public delegate void EveHandDeleteText(object sender, EventArgs e);
//アイテムフラグ用のイベント
public delegate void EveHandFlagItem(object sender, EventArgs e);
//デバッグ用のイベント
public delegate void EveHandDebug(object sender, EventArgs e);
//タイマー制御用のイベント
public delegate void EveHandMzTimer(object sender, EventArgs e);
//プレイヤー反映用のイベント
public delegate void EveHandToPlayer(object sender, EventArgs e);
//出現壁ギミックのイベント
public delegate void EveHandWallGimmick01(object sender, EventArgs e);
//フェード関連のイベント
public delegate void EveHandFadeImage(object sender, EventArgs e);
//鍵取得時のイベント
public delegate void EveHandItemKey(object sender, EventArgs e);


//各面選択用のイベント
public delegate void EveHandGoToMaze(object sender, int i);
//タイマー増減用のイベント
public delegate void EveHandMzTimeUpDown(object sender, int i);
//プレイヤーパラメータ増減用のイベント
public delegate void EveHandPlayerValue(object sender, float i);
//DirectionalLight用のイベント
public delegate void EveHandDirLight(object sender, float i);
//SpotLight用のイベント
public delegate void EveHandSpotLight(object sender, float i);
//鍵取得時のイベント
public delegate void EveHandItemKeyValue(object sender, int i);