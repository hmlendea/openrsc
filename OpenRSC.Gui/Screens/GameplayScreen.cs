﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using NuciXNA.Primitives;

using OpenRSC.Gui.GuiElements;
using OpenRSC.Net.Client.Events;

namespace OpenRSC.Gui.Screens
{
    /// <summary>
    /// Gameplay screen.
    /// </summary>
    public class GameplayScreen : Screen
    {
        /// <summary>
        /// Gets or sets the minimap.
        /// </summary>
        /// <value>The minimap.</value>
        public GuiSideBar SideBar { get; set; }

        public GuiChatPanel ChatPanel { get; set; }

        /// <summary>
        /// Gets or sets the game client.
        /// </summary>
        /// <value>The game client.</value>
        public GuiGame GameClient { get; set; }

        /// <summary>
        /// Loads the content.
        /// </summary>
        public override void LoadContent()
        {
            SideBar = new GuiSideBar();
            ChatPanel = new GuiChatPanel();
            GameClient = new GuiGame();

            SideBar.Enabled = false;
            SideBar.Visible = false;

            GuiManager.Instance.GuiElements.Add(GameClient);
            GuiManager.Instance.GuiElements.Add(SideBar);
            GuiManager.Instance.GuiElements.Add(ChatPanel);

            base.LoadContent();

            SideBar.AssociateGameClient(ref GameClient.gameClient);
        }

        /// <summary>
        /// Update the content.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="gameTime">Game time.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (GameClient.gameClient.loggedIn)
            {
                SideBar.Enabled = true;
                SideBar.Visible = true;
            }
            else
            {
                SideBar.Enabled = false;
                SideBar.Visible = false;
            }
        }

        /// <summary>
        /// Draw the content on the specified spriteBatch.
        /// </summary>
        /// <returns>The draw.</returns>
        /// <param name="spriteBatch">Sprite batch.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        protected override void SetChildrenProperties()
        {
            SideBar.Size = new Size2D(240, ScreenManager.Instance.Size.Height);
            SideBar.Location = new Point2D(ScreenManager.Instance.Size.Width - SideBar.Size.Width, 0);

            ChatPanel.Size = new Size2D(
                ScreenManager.Instance.Size.Width - SideBar.Size.Width,
                (int)(ScreenManager.Instance.Size.Height * 0.25));
            ChatPanel.Location = new Point2D(0, ScreenManager.Instance.Size.Height - ChatPanel.Size.Height);

            GameClient.Size = new Size2D(
                ScreenManager.Instance.Size.Width - SideBar.Size.Width,
                ScreenManager.Instance.Size.Height - ChatPanel.Size.Height);
        }

        protected override void RegisterEvents()
        {
            GameClient.gameClient.OnChatMessageReceived += GameClient_OnChatMessageReceived;
        }

        protected override void UnregisterEvents()
        {
            GameClient.gameClient.OnChatMessageReceived -= GameClient_OnChatMessageReceived;
        }

        void GameClient_OnChatMessageReceived(object sender, ChatMessageEventArgs e)
        {
            ChatPanel.AddMessage(e.Message);
        }
    }
}
