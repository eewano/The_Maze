using System;

//ManagerMzMasterの各ステートで処理されるイベント
public delegate void EveHandMgrState(object sender, EventArgs e);
//ManagerMzMasterのステート移動の際のイベント
public delegate void EveHandMoveState(object sender, EventArgs e);
//SEサウンドを鳴らす為のイベント
public delegate void EveHandPLAYSE(object sender, EventArgs e);

public delegate void EveHandDeleteText(object sender, EventArgs e);
//アイテムフラグ用のイベント
public delegate void EveHandFlagItem(object sender, EventArgs e);
//デバッグ用のイベント
public delegate void EveHandDebug(object sender, EventArgs e);
//各面選択用のイベント
public delegate void EveHandGoToMaze(object sender, int i);