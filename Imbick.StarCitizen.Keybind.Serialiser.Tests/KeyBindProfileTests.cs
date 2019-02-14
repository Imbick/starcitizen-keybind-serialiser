
namespace Imbick.StarCitizen.Keybind.Serialiser.Tests {
    using System.Collections.Generic;
    using System.Linq;
    using Model;
    using Xunit;

    public class KeyBindProfileTests {
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
            var first = new ActionMaps {
                actionmap = new List<ActionMapsActionmap> {
                    new ActionMapsActionmap {
                        name = "some_actionmap",
                        action = new List<ActionMapsActionmapAction> {
                            new ActionMapsActionmapAction {
                                name = "some_action",
                                rebind = new ActionMapsActionmapActionRebind {input = "some_input"}
                            },
                            new ActionMapsActionmapAction {
                                name = "some_other_action",
                                rebind = new ActionMapsActionmapActionRebind {input = "some_other_input"}
                            }
                        }
                    },
                    new ActionMapsActionmap {
                        name = "some_other_actionmap",
                        action = new List<ActionMapsActionmapAction> {
                            new ActionMapsActionmapAction {
                                name = "some_other_action_again",
                                rebind = new ActionMapsActionmapActionRebind {input = "some_other_input_again"}
                            }
                        }
                    }
                }
            };
            var second = new ActionMaps {
                actionmap = new List<ActionMapsActionmap> {
                    new ActionMapsActionmap {
                        name = "some_actionmap",
                        action = new List<ActionMapsActionmapAction> {
                            new ActionMapsActionmapAction {
                                name = "some_action",
                                rebind = new ActionMapsActionmapActionRebind {input = "some_new_input"}
                            }
                        }
                    }
                }
            };

            first.Apply(second);

            Assert.Equal(2, first.actionmap.Count);
            Assert.Contains(first.actionmap, a => a.name == "some_actionmap");

            var actionMap = first.actionmap.First(a => a.name == "some_actionmap");
            Assert.Equal(2, actionMap.action.Count);
            Assert.Contains(actionMap.action, a => a.name == "some_action");

            var action = actionMap.action.First(a => a.name == "some_action");
            Assert.Equal("some_new_input", action.rebind.input);

            Assert.Equal(1, first.actionmap.SelectMany(a => a.action).Count(a => a.name == "some_action"));
        }

        [Fact]
        public void Apply_WithoutOverride_AppendsNewAction() {

        }
    }
}