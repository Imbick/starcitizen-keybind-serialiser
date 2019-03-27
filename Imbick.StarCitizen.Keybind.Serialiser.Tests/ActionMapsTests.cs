
namespace Imbick.StarCitizen.Keybind.Serialiser.Tests {
    using System.Collections.Generic;
    using System.Linq;
    using Model;
    using Xunit;

    public class ActionMapsTests {

        [Fact]
        public void Default_Always_DeserialisesFile() {
            var defaultProfile = ActionMaps.Default;

            //here we're just checking that _something_ got deserialised. As the notion of 'default' is a moving target.
            Assert.NotNull(defaultProfile);
            Assert.True(defaultProfile.actionmap.Any());
            Assert.True(defaultProfile.actionmap.Any(a => a.action.Any()));
            Assert.True(defaultProfile.actionmap.Any(m => m.action.Any(a => a.rebind.input.Any())));
        }

        [Fact]
        public void Apply_WithOverride_OverwritesCorrectAction() {

            _first.Apply(_second);

            Assert.Equal(2, _first.actionmap.Count);
            Assert.Contains(_first.actionmap, a => a.name == "some_actionmap");

            var actionMap = _first.actionmap.First(a => a.name == "some_actionmap");
            Assert.Equal(2, actionMap.action.Count);
            Assert.Contains(actionMap.action, a => a.name == "some_action");

            var action = actionMap.action.First(a => a.name == "some_action");
            Assert.Equal("kb1_0", action.rebind.input);

            Assert.Equal(1, _first.actionmap.SelectMany(a => a.action).Count(a => a.name == "some_action"));
        }

        [Fact]
        public void Apply_WithNewActionMap_AddsActionMap() {
            var second = new ActionMaps
            {
                actionmap = new List<ActionMapsActionmap> {
                    new ActionMapsActionmap {
                        name = "some_new_actionmap",
                        action = new List<ActionMapsActionmapAction> {
                            new ActionMapsActionmapAction {
                                name = "some_action",
                                rebind = new ActionMapsActionmapActionRebind {input = "kb1_0"}
                            }
                        }
                    }
                }
            };
            _first.Apply(second);
            Assert.Equal(3, _first.actionmap.Count);
            Assert.Contains(_first.actionmap, a => a.name == second.actionmap.First().name);
            Assert.Single(_first.actionmap.First(a => a.name == second.actionmap.First().name).action);
        }

        [Fact]
        public void Apply_WithNewAction_AddsActionToExistingMap()
        {
            var second = new ActionMaps
            {
                actionmap = new List<ActionMapsActionmap> {
                    new ActionMapsActionmap {
                        name = "some_actionmap",
                        action = new List<ActionMapsActionmapAction> {
                            new ActionMapsActionmapAction {
                                name = "some_new_action",
                                rebind = new ActionMapsActionmapActionRebind {input = "kb1_0"}
                            }
                        }
                    }
                }
            };
            _first.Apply(second);
            Assert.Equal(2, _first.actionmap.Count);
            Assert.Equal(3, _first.actionmap.First(a => a.name == second.actionmap.First().name).action.Count);
        }

        [Fact]
        public void ToDictionary_Always_ProducesCorrectDictionary() {
            _first.actionmap.First().action.First().rebind.input += "+l";
            var dictionary = _first.ToDictionary();

            Assert.Equal(2, dictionary.Count);
            Assert.True(dictionary.ContainsKey(_first.actionmap.First().name));
            Assert.True(dictionary.ContainsKey(_first.actionmap.Last().name));
            Assert.Equal(2, dictionary.First().Value.Count);
            Assert.Equal(1, dictionary.Last().Value.Count);
            Assert.True(dictionary.First().Value.ContainsKey("some_action"));
            Assert.True(dictionary.First().Value.ContainsKey("some_other_action"));
            Assert.True(dictionary.Last().Value.ContainsKey("some_other_action_again"));
            Assert.Equal(2, dictionary.First().Value.First().Value.Inputs.Count());
            Assert.Equal(KeyBindInput.backspace, dictionary.First().Value.First().Value.Inputs.First());
            Assert.Equal(KeyBindInput.l, dictionary.First().Value.First().Value.Inputs.Last());
            Assert.Equal(ActivationMode.double_tap, dictionary.First().Value.First().Value.ActivationMode);
            Assert.Equal(ActivationMode.none, dictionary.First().Value.Last().Value.ActivationMode);
        }


        private ActionMaps _first = new ActionMaps
        {
            actionmap = new List<ActionMapsActionmap> {
                new ActionMapsActionmap {
                    name = "some_actionmap",
                    action = new List<ActionMapsActionmapAction> {
                        new ActionMapsActionmapAction {
                            name = "some_action",
                            rebind = new ActionMapsActionmapActionRebind {input = "backspace", activationMode = "double_tap"}
                        },
                        new ActionMapsActionmapAction {
                            name = "some_other_action",
                            rebind = new ActionMapsActionmapActionRebind {input = "comma"}
                        }
                    }
                },
                new ActionMapsActionmap {
                    name = "some_other_actionmap",
                    action = new List<ActionMapsActionmapAction> {
                        new ActionMapsActionmapAction {
                            name = "some_other_action_again",
                            rebind = new ActionMapsActionmapActionRebind {input = "kb1_enter"}
                        }
                    }
                }
            }
        };
        private ActionMaps _second = new ActionMaps
        {
            actionmap = new List<ActionMapsActionmap> {
                new ActionMapsActionmap {
                    name = "some_actionmap",
                    action = new List<ActionMapsActionmapAction> {
                        new ActionMapsActionmapAction {
                            name = "some_action",
                            rebind = new ActionMapsActionmapActionRebind {input = "kb1_0"}
                        }
                    }
                }
            }
        };

    }
}