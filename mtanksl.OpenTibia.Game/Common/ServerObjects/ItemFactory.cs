﻿using OpenTibia.Common.Objects;
using OpenTibia.Common.Structures;
using OpenTibia.FileFormats.Dat;
using OpenTibia.FileFormats.Otb;
using OpenTibia.FileFormats.Xml.Items;
using OpenTibia.Game.GameObjectScripts;
using System.Collections.Generic;
using System.Linq;
using Item = OpenTibia.Common.Objects.Item;
using ItemFlags = OpenTibia.FileFormats.Dat.ItemFlags;

namespace OpenTibia.Game.Common.ServerObjects
{
    public class ItemFactory : IItemFactory
    {
        private HashSet<ushort> lockers;
        private HashSet<ushort> doors;

        private IServer server;

        public ItemFactory(IServer server)
        {
            this.server = server;
        }

        public void Start(OtbFile otbFile, DatFile datFile, ItemsFile itemsFile)
        {
            lockers = server.Values.GetUInt16HashSet("values.items.lockers");

            doors = new HashSet<ushort>();

            foreach (var item in server.Values.GetUInt16IUnt16Dictionary("values.items.transformation.openDoors") )
            {
                doors.Add(item.Key);
            }

            foreach (var item in server.Values.GetUInt16IUnt16Dictionary("values.items.transformation.closeHorizontalDoors") )
            {
                doors.Add(item.Key);
            }

            foreach (var item in server.Values.GetUInt16IUnt16Dictionary("values.items.transformation.closeVerticalDoors") )
            {
                doors.Add(item.Key);
            }

            foreach (var item in server.Values.GetUInt16HashSet("values.items.lockedDoors") )
            {
                doors.Add(item);
            }

            openTibiaMetadatas = new Dictionary<ushort, ItemMetadata>(datFile.Items.Count);

            tibiaMetadatas = new Dictionary<ushort, List<ItemMetadata> >(datFile.Items.Count);

            foreach (var otbItem in otbFile.Items)
            {
                if (otbItem.Group != ItemGroup.Deprecated)
                {
                    ItemMetadata metadata = new ItemMetadata()
                    {
                        TibiaId = otbItem.TibiaId,

                        OpenTibiaId = otbItem.OpenTibiaId,
                    };

                    if (otbItem.Flags.Is(FileFormats.Otb.ItemFlags.AllowDistanceRead) )
                    {
                        metadata.Flags |= ItemMetadataFlags.AllowDistanceRead;
                    }

                    openTibiaMetadatas.Add(otbItem.OpenTibiaId, metadata);

                    List<ItemMetadata> metadatas;

                    if ( !tibiaMetadatas.TryGetValue(otbItem.TibiaId, out metadatas) )
                    {
                        metadatas = new List<ItemMetadata>();

                        tibiaMetadatas.Add(otbItem.TibiaId, metadatas);                        
                    }

                    metadatas.Add(metadata);
                }
            }

            foreach (var datItem in datFile.Items)
            {
                foreach (var metadata in tibiaMetadatas[datItem.TibiaId] )
                {
                    if (datItem.Flags.Is(ItemFlags.IsGround) )
                    {
                        metadata.TopOrder = TopOrder.Ground;
                    }
                    else if (datItem.Flags.Is(ItemFlags.AlwaysOnTop1) )
                    {
                        metadata.TopOrder = TopOrder.HighPriority;
                    }
                    else if (datItem.Flags.Is(ItemFlags.AlwaysOnTop2) )
                    {
                        metadata.TopOrder = TopOrder.MediumPriority;
                    }
                    else if (datItem.Flags.Is(ItemFlags.AlwaysOnTop3) )
                    {
                        metadata.TopOrder = TopOrder.LowPriority;
                    }
                    else
                    {
                        metadata.TopOrder = TopOrder.Other;
                    }

                    if (datItem.Flags.Is(ItemFlags.IsContainer) )
                    {
                        metadata.Flags |= ItemMetadataFlags.IsContainer;
                    }

                    if (datItem.Flags.Is(ItemFlags.Stackable) )
                    {
                        metadata.Flags |= ItemMetadataFlags.Stackable;
                    }

                    if (datItem.Flags.Is(ItemFlags.Useable) )
                    {
                        metadata.Flags |= ItemMetadataFlags.Useable;
                    }

                    if (datItem.Flags.Is(ItemFlags.Writeable) )
                    {
                        metadata.Flags |= ItemMetadataFlags.Writeable;
                    }
                      
                    if (datItem.Flags.Is(ItemFlags.Readable) )
                    {
                        metadata.Flags |= ItemMetadataFlags.Readable;
                    }

                    if (datItem.Flags.Is(ItemFlags.IsFluid) )
                    {
                        metadata.Flags |= ItemMetadataFlags.IsFluid;
                    }

                    if (datItem.Flags.Is(ItemFlags.IsSplash) )
                    {
                        metadata.Flags |= ItemMetadataFlags.IsSplash;
                    }

                    if (datItem.Flags.Is(ItemFlags.NotWalkable) )
                    {
                        metadata.Flags |= ItemMetadataFlags.NotWalkable;
                    }

                    if (datItem.Flags.Is(ItemFlags.NotMoveable) )
                    {
                        metadata.Flags |= ItemMetadataFlags.NotMoveable;
                    }

                    if (datItem.Flags.Is(ItemFlags.BlockProjectile) )
                    {
                        metadata.Flags |= ItemMetadataFlags.BlockProjectile;
                    }

                    if (datItem.Flags.Is(ItemFlags.BlockPathFinding) )
                    {
                        metadata.Flags |= ItemMetadataFlags.BlockPathFinding;
                    }

                    if (datItem.Flags.Is(ItemFlags.Pickupable) )
                    {
                        metadata.Flags |= ItemMetadataFlags.Pickupable;
                    }

                    if (datItem.Flags.Is(ItemFlags.Hangable) )
                    {
                        metadata.Flags |= ItemMetadataFlags.Hangable;
                    }

                    if (datItem.Flags.Is(ItemFlags.Horizontal) )
                    {
                        metadata.Flags |= ItemMetadataFlags.Horizontal;
                    }

                    if (datItem.Flags.Is(ItemFlags.Vertical) )
                    {
                        metadata.Flags |= ItemMetadataFlags.Vertical;
                    }

                    if (datItem.Flags.Is(ItemFlags.Rotatable) )
                    {
                        metadata.Flags |= ItemMetadataFlags.Rotatable;
                    }

                    if (datItem.ItemHeight > 0)
                    {
                        metadata.Flags |= ItemMetadataFlags.HasHeight;
                    }

                    metadata.Speed = datItem.Speed;

                    metadata.MaxWriteChars = datItem.MaxWriteChars;

                    metadata.MaxReadChars = datItem.MaxReadChars;

                    if (datItem.LightLevel > 0 || datItem.LightColor > 0)
                    {
                        metadata.Light = new Light( (byte)datItem.LightLevel, (byte)datItem.LightColor);
                    }
                }
            }

            foreach (var xmlItem in itemsFile.Items)
            {
                if (xmlItem.OpenTibiaId < 20000)
                {
                    ItemMetadata metadata = openTibiaMetadatas[xmlItem.OpenTibiaId];

                    metadata.Article = xmlItem.Article;

                    metadata.Name = xmlItem.Name;

                    metadata.Plural = xmlItem.Plural;

                    metadata.Description = xmlItem.Description;

                    metadata.RuneSpellName = xmlItem.RuneSpellName;

                    metadata.Weight = xmlItem.Weight;

                    metadata.Armor = xmlItem.Armor;

                    metadata.Defense = xmlItem.Defense;

                    metadata.ExtraDefense = xmlItem.ExtraDefense;

                    if (xmlItem.BlockProjectile == true)
                    {
                        metadata.Flags |= ItemMetadataFlags.BlockProjectile;
                    }

                    metadata.Attack = xmlItem.Attack;

                    metadata.AttackStrength = xmlItem.AttackStrength;

                    metadata.AttackVariation = xmlItem.AttackVariation;

                    metadata.FloorChange = xmlItem.FloorChange;

                    metadata.Capacity = xmlItem.ContainerSize;

                    if (metadata.Capacity != null)
                    {
                        metadata.Flags |= ItemMetadataFlags.IsContainer;
                    }

                    metadata.WeaponType = xmlItem.WeaponType;

                    metadata.AmmoType = xmlItem.AmmoType;

                    metadata.ProjectileType = xmlItem.ProjectileType;

                    metadata.MagicEffectType = xmlItem.MagicEffectType;

                    metadata.Range = xmlItem.Range;

                    metadata.Charges = xmlItem.Charges;

                    metadata.SlotType = xmlItem.SlotType;

                    if (xmlItem.Readable == true)
                    {
                        metadata.Flags |= ItemMetadataFlags.Readable;
                    }

                    if (xmlItem.Writeable == true)
                    {
                        metadata.Flags |= ItemMetadataFlags.Writeable;
                    }
                }
            }
        }

        private Dictionary<ushort, ItemMetadata> openTibiaMetadatas;

        public ItemMetadata GetItemMetadataByOpenTibiaId(ushort openTibiaId)
        {
            ItemMetadata metadata;

            if (openTibiaMetadatas.TryGetValue(openTibiaId, out metadata) )
            {
                return metadata;
            }

            return null;
        }

        private Dictionary<ushort, List<ItemMetadata> > tibiaMetadatas;

        public ItemMetadata GetItemMetadataByTibiaId(ushort tibiaId)
        {
            List<ItemMetadata> metadatas;

            if (tibiaMetadatas.TryGetValue(tibiaId, out metadatas) )
            {
                return metadatas.FirstOrDefault();
            }

            return null;
        }

        public Item Create(ushort openTibiaId, byte count)
        {
            ItemMetadata metadata = GetItemMetadataByOpenTibiaId(openTibiaId);

            if (metadata == null)
            {
                return null;
            }

            Item item;

            if (openTibiaId == 1387)
            {
                item = new TeleportItem(metadata);
            }
            else if (lockers.Contains(openTibiaId) )
            {
                item = new Locker(metadata);
            }
            else if (doors.Contains(openTibiaId) )
            {
                item = new DoorItem(metadata);
            }
            else if (metadata.Flags.Is(ItemMetadataFlags.IsContainer) )
            {
                item = new Container(metadata);
            }
            else if (metadata.Flags.Is(ItemMetadataFlags.Stackable) )
            {
                item = new StackableItem(metadata)
                {
                    Count = count 
                };
            }
            else if (metadata.Flags.Is(ItemMetadataFlags.IsFluid) )
            {
                item = new FluidItem(metadata)
                {
                    FluidType = (FluidType)count 
                };
            }
            else if (metadata.Flags.Is(ItemMetadataFlags.IsSplash) )
            {
                item = new SplashItem(metadata)
                {
                    FluidType = (FluidType)count 
                };
            }
            else if (metadata.Flags.Is(ItemMetadataFlags.Writeable) || metadata.Flags.Is(ItemMetadataFlags.Readable) || metadata.Flags.Is(ItemMetadataFlags.AllowDistanceRead) )
            {
                item = new ReadableItem(metadata);
            }
            else
            {
                item = new Item(metadata);
            }

            return item;
        }

        public void Attach(Item item)
        {
            item.IsDestroyed = false;

            server.GameObjects.AddGameObject(item);

            GameObjectScript<Item> gameObjectScript = server.GameObjectScripts.GetItemGameObjectScript(item.Metadata.OpenTibiaId);

            if (gameObjectScript != null)
            {
                gameObjectScript.Start(item);
            }
        }

        public bool Detach(Item item)
        {
            if (server.GameObjects.RemoveGameObject(item) )
            {
                GameObjectScript<Item> gameObjectScript = server.GameObjectScripts.GetItemGameObjectScript(item.Metadata.OpenTibiaId);

                if (gameObjectScript != null)
                {
                    gameObjectScript.Stop(item);
                }

                return true;
            }

            return false;
        }

        public void ClearComponentsAndEventHandlers(Item item)
        {
            server.GameObjectComponents.ClearComponents(item);

            server.GameObjectEventHandlers.ClearEventHandlers(item);
        }
    }
}